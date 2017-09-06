using Application.DAL.Contracts;
using Application.Model;
using Application.Model.DTO;
using Application.Repository;
using Application.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Security;

namespace Application.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        IUnitOfWork _unitOfWork;
        ICustomerRepository _customerRepository;
       

        public CustomerService(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository
            )
        {
            this._unitOfWork = unitOfWork;
            this._customerRepository = customerRepository;
           
        }

        //Below method will create any random strigs of given size. Basically this type of algorithm reads the memory at random locations to form
        //the complete random string each time
        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        //The salt created in above function will be appended to the real password
        //and again SHA1 algorithm will be used to generate the hash which will eventually stored in database
        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }

        public CustomerDTO ValidateCustomer(int id, string password)
        {
            Customer objCustomer = _customerRepository.GetById(id);
            if (objCustomer == null)
                return null;
            string strPasswordHash = objCustomer.PasswordHash;
            string strPasswordSalt = strPasswordHash.Substring(strPasswordHash.Length - 8);
            string strPasword = CreatePasswordHash(password, strPasswordSalt);

            if (strPasword.Equals(strPasswordHash))
                return CreateCustomerDTO(objCustomer);
            else
                return null;
        }

        public int SaveOrUpdateCustomer(CustomerDTO customer)
        {
            string passwordSalt = CreateSalt(5);
            string pasword = CreatePasswordHash(customer.Password, passwordSalt);
            Customer objCustomer;

            if (customer.CustomerID != 0)
                objCustomer = _customerRepository.GetById(customer.CustomerID);
            else
                objCustomer = new Customer();

            objCustomer.NameStyle = customer.NameStyle;
            objCustomer.Title = customer.Title;
            objCustomer.FirstName = customer.FirstName;
            objCustomer.MiddleName = customer.MiddleName;
            objCustomer.LastName = customer.LastName;
            objCustomer.Suffix = customer.Suffix;
            objCustomer.CompanyName = customer.CompanyName;
            objCustomer.SalesPerson = customer.SalesPerson;
            objCustomer.EmailAddress = customer.EmailAddress;
            objCustomer.Phone = customer.Phone;
            objCustomer.PasswordHash = pasword;
            objCustomer.PasswordSalt = passwordSalt;
            objCustomer.ModifiedDate = DateTime.Now;
            objCustomer.rowguid = Guid.NewGuid();

            if (customer.CustomerID != 0)
                _customerRepository.Update(objCustomer);
            else
                _customerRepository.Add(objCustomer);

            _unitOfWork.Commit();
            
            return objCustomer.CustomerID;
        }

        

        private CustomerDTO CreateCustomerDTO(Customer customer)
        {
            CustomerDTO objCustomerDTO = new CustomerDTO();
            objCustomerDTO.CustomerID = customer.CustomerID;
            objCustomerDTO.NameStyle = customer.NameStyle;
            objCustomerDTO.Title = customer.Title;
            objCustomerDTO.FirstName = customer.FirstName;
            objCustomerDTO.MiddleName = customer.MiddleName;
            objCustomerDTO.LastName = customer.LastName;
            objCustomerDTO.Suffix = customer.Suffix;
            objCustomerDTO.CompanyName = customer.CompanyName;
            objCustomerDTO.SalesPerson = customer.SalesPerson;
            objCustomerDTO.EmailAddress = customer.EmailAddress;
            objCustomerDTO.Phone = customer.Phone;
            objCustomerDTO.Password = customer.PasswordHash;

            
            return objCustomerDTO;
        }
    }
}

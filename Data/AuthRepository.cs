using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Data
{
    public class AuthRepository : IAuthRespository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
            
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
            if (user is null)
            {
                response.status = false;
                response.Mymessage = "User Not Found";
            }
            else if (!VerifyPassword(password, user.passwordHash, user.passwordSalt)){
                response.status = false;
                response.Mymessage = "Incorrect Password";
            }else{
                response.Mymessage = "Successfully Logged In ";
                response.data =user.Id.ToString();
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(Users users, string password)
        {
           var response = new ServiceResponse<int>();

            if (await UserExists(users.Username) )
            {
                response.status = false;
                response.Mymessage = "User Already Exists !";
            }
         createPasswordHash( password, out byte[] passwordHash, out byte[] passwordSalt);

         users.passwordHash = passwordHash;
         users.passwordSalt = passwordSalt;

           _context.Users.Add(users);
           await _context.SaveChangesAsync();
           response.data = users.Id;
           return response;
        }

        public async Task<bool> UserExists(string username)
        {
           if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower())){
            return true;
           }
           return false;
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using ( var hmac = new System.Security.Cryptography.HMACSHA512()){
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
            }
        }

        private bool VerifyPassword (string password, byte[] passwordHash, byte[] passwordSalt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

        }
    }
}
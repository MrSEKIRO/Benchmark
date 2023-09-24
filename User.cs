using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
	public class InternalUser
	{
        public string Name { get; internal set; }
        public string Password { get; internal set; }
        public string Email { get; internal set; }
        public int Age { get; internal set; }
        public decimal Balance { get; internal set; }

        public InternalUser(string name, string password, string email, int age, decimal balance)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            Balance = balance;
        }
    }

    public class PublicUser
    {
		public string Name { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public decimal Balance { get; set; }
	}

    public class UserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal Balance { get; set; }
    }

    public static class UserDtoExtenstion
    {
        public static InternalUser ToInternalUser(this UserDto dto)
        {
			//return new User()
            //{
			//	Name = dto.Name,
			//	Password = dto.Password,
			//	Email = dto.Email,
			//	Age = dto.Age,
			//	Balance = dto.Balance
			//};

            return new InternalUser(dto.Name, dto.Password, dto.Email, dto.Age, dto.Balance);
		}

        public static PublicUser ToPublicUser(this UserDto dto)
        {
			return new PublicUser()
            {
				Name = dto.Name,
				Password = dto.Password,
				Email = dto.Email,
				Age = dto.Age,
				Balance = dto.Balance
			};
		}
    }
}

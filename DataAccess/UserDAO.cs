using System;
using DTO;
using BusinessObjects;
using Utils;
namespace DataAccess
{
	public class UserDAO
	{
		private static UserDAO? instance = null;
		private static readonly object instanceLock = new object();
		public UserDAO() { }
		public static UserDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new UserDAO();
					}
					return instance;
				}
			}
		}
		//-----------------------------------------------
		public List<UserDTO> GetUser()
		{
			var list = new List<User>();
			var listDTO = new List<UserDTO>();
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					list = context.Users.ToList();
					foreach (var item in list)
					{
						listDTO.Add(new UserDTO
						{
							UserId = item.UserId,
							Username = item.Username,
							Password = item.Password,
							Email = item.Email,
							Phone = item.Phone,
							Address = item.Address
						});
					}
				}

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listDTO;
		}
		//-----------------------------------------------
		public UserDTO FindUserById(int id)
		{
			User user = new User();
			UserDTO userDTO = new UserDTO();
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					user = context.Users.SingleOrDefault(x => x.UserId == id);
					userDTO.UserId = user.UserId;
					userDTO.Username = user.Username;
					userDTO.Password = user.Password;
					userDTO.Email = user.Email;
					userDTO.Phone = user.Phone;
					userDTO.Address = user.Address;
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return userDTO;
		}
		//----------------------------------------------
		public List<UserDTO> GetUserByEmail(string email)
		{
			var list = new List<User>();
			var listDTO = new List<UserDTO>();
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					list = context.Users.Where(x => x.Email.Equals(email)).ToList();
					foreach (var item in list)
					{
						listDTO.Add(new UserDTO
						{
							UserId = item.UserId,
							Username = item.Username,
							Password = item.Password,
							Email = item.Email,
							Phone = item.Phone,
							Address = item.Address
						});
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listDTO;
		}
		//----------------------------------------------
		public bool CheckUserByEmailAndPassword(string email, string password)
		{
			User user = new User();
			bool check = false;
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					user = context.Users.SingleOrDefault(x => x.Email.Equals(email));
					if (HashPasswordUtility.VerifyPassword(password, user.Password))
					{
						check = true;
					}
					else
					{
						check = false;
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return check;
		}
		//----------------------------------------------
		public void SaveUser(UserDTO user)
		{
			User userTemp = new User();
			userTemp.Username = user.Username;
			userTemp.Password = HashPasswordUtility.HashPassword(user.Password ?? "");
			userTemp.Email = user.Email;
			userTemp.Phone = user.Phone;
			userTemp.Address = user.Address;
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					context.Users.Add(userTemp);
					context.SaveChanges();
				}

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		//----------------------------------------------
		public void UpdateUser(UserDTO user)
		{
			User userTemp = new User();
			userTemp.UserId = user.UserId;
			userTemp.Username = user.Username;
			userTemp.Password = HashPasswordUtility.HashPassword(user.Password ?? "");
			userTemp.Email = user.Email;
			userTemp.Phone = user.Phone;
			userTemp.Address = user.Address;
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					context.Entry<User>(userTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.Users.Update(userTemp);
					context.SaveChanges();
				}

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		//----------------------------------------------
		public void DeleteUserById(int id)
		{
			try
			{
				using (var context = new CozaStoreDbContext())
				{
					var user = context.Users.SingleOrDefault(c => c.UserId == id);
					context.Users.Remove(user);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		//----------------------------------------------
	}
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
	public class LoginViewModel
	{
		[Required]
		[DisplayName("ユーザ名")]
		public string UserName { get; set; }

		[Required]
		[DisplayName("パスワード")]
		public string Password { get; set; }
	}
}
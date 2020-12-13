using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
	public class Todolist
	{
		public int Id { get; set; }

		[DisplayName("タスク")]
		[Required]
		public string Task { get; set; }

		[DisplayName("期限")]
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime LimitDate { get; set; }

		[DisplayName("優先度")]
		public string Priority { get; set; }

		[DisplayName("完了")]
		public bool Done { get; set; }
	}

	public class TodolistsContext: DbContext
	{
		public DbSet<Todolist> Todolists { get; set; }
	}
}
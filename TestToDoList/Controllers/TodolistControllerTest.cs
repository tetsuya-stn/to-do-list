using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Controllers;
using ToDoList.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace TestToDoList.Controllers
{
	[TestClass]
	public class TodolistControllerTest
	{
		[TestMethod]
		public void Index()
		{
			var controller = new TodolistsController();
			var result = controller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Create()
		{
			var controller = new TodolistsController();
			var result = controller.Create() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void PostCreate()
		{
			var mockset = new Mock<DbSet<Todolist>>();
			var mockcontext = new Mock<TodolistsContext>();

			mockcontext.Setup(m => m.Todolists).Returns(mockset.Object);
			
			var model = new Todolist
			{
				Id = 0,
				Task = "内容",
				LimitDate = DateTime.Now,
				Priority = string.Empty,
				Done = false
			};

			var controller = new TodolistsController();
			var result = controller.Create(model) as RedirectToRouteResult;
			Assert.IsNotNull(result);
			/*
			mockset.Verify(m => m.Add(It.Is<Todolist>(o => o.Id == model.Id
			                                            && o.Task == model.Task
														&& o.LimitDate == model.LimitDate
														&& o.Priority == model.Priority
														&& o.Done == model.Done)), Times.Once);
			
			mockcontext.Verify(m => m.SaveChanges(), Times.Once);
			*/
		}

		[TestMethod]
		public void Detail()
		{
			var controller = new TodolistsController();
			var result = controller.Details(1) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Edit()
		{
			var controller = new TodolistsController();
			var result = controller.Edit(1) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void PostEdit()
		{
			var controller = new TodolistsController();


		}
	}
}

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using DataService;
using Matrix.Net.CoreService;
using Matrix.Net.Domain;
using Matrix.Net.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
                                                                
namespace Matrix.Net.Server.WebApi.Controllers
{
	[System.Web.Http.Authorize(Roles ="Administrator")]
	[ApiController]
	[System.Web.Http.Route("[controller]")]
	public class MessageController : ControllerBase
	{
		private readonly ILogger<MessageController> _logger;
		private readonly IMatrixMessageService _matrix;
		private readonly IMatrixService _matrixService;

		public MessageController(ILogger<MessageController> logger, IMatrixMessageService matrix, IMatrixService matrixService)
		{
			_logger = logger;
			_matrix = matrix;
			_matrixService = matrixService;
		}

		[System.Web.Http.AllowAnonymous]
		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("Incoming/{number:int}")]
		[ProducesResponseType(typeof(Message), 200)]
		[ProducesResponseType(typeof(MessageNotFoundException), 500)]
		public IActionResult GetIncoming(int number)
		{
			_logger.LogInformation("Request for incoming message " + number);
			try
			{
				var message = _matrix.GetIncomingMessage(number);
				if (message == null)
					throw new MessageNotFoundException(number);

				return Ok(message);

			}
			catch (MessageNotFoundException msgEx)
			{
				return StatusCode(500, msgEx);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("Outgoing/{number:int}")]
		[ProducesResponseType(typeof(Message), 200)]
		[ProducesResponseType(typeof(MessageNotFoundException), 500)]
		public IActionResult GetOutgoing(int number)
		{
			_logger.LogInformation("Request for outgoing message " + number);
			try
			{
				var message = _matrix.GetIncomingMessage(number);
				if (message == null)
					throw new MessageNotFoundException(number);

				return Ok(message);

			}
			catch (MessageNotFoundException msgEx)
			{
				return StatusCode(500, msgEx);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("Internal/{number:int}")]
		[ProducesResponseType(typeof(Message), 200)]
		[ProducesResponseType(typeof(MessageNotFoundException), 500)]
		public IActionResult GetInternal(int number)
		{
			_logger.LogInformation("Request for internal message " + number);
			try
			{
				var message = _matrixService.GetInternalMessage(number);
				if (message == null)
					throw new MessageNotFoundException(number);

				return Ok(message);

			}
			catch (MessageNotFoundException msgEx)
			{
				return StatusCode(500, msgEx);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("AllMessages/{number:int}")]
		[ProducesResponseType(typeof(Message), 200)]
		[ProducesResponseType(typeof(MessageNotFoundException), 500)]
		public IActionResult GetAll(int number)
		{
			_logger.LogInformation("Request for AllMessages message " + number);
			try
			{
				var message = _matrixService.GetAllMessage(number);
				if (message == null)
					throw new MessageNotFoundException(number);

				return Ok(message);

			}
			catch (MessageNotFoundException msgEx)
			{
				return StatusCode(500, msgEx);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}




		[System.Web.Http.Route("All")]
		[ProducesResponseType(typeof(IEnumerable<Message>), 200)]
		public IActionResult All()
		{
			var messages = new List<Message>
			{
				new Message
				{
					Number = 1348970, Direction = MessageDirection.Incoming
				},
				new Message
				{
					Number = 1348970, Direction = MessageDirection.Internal
				},
				new Message
				{
					Number = 1348970, Direction = MessageDirection.AllMessages
				},

				new Message
				{
					Number = 1348970, Direction = MessageDirection.Outgoing
				},
			};

			return Ok(messages);
		}

		public static void Register(HttpConfiguration config)
		{
			config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
		}
	}
}

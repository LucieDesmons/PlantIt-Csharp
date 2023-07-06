using BLL.Interfaces;
using DATA.DAL.Entities;
using DATA.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public ActionResult<List<ConversationDto>> LoadConversationOfUser(int idUser) 
        {
            try
            {
                var userConv = _chatService.GetConversationsOfUser(idUser);
                return Ok(userConv);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur est survenue lors du chargement des conversations de l'utilisateur");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<ConversationDto> StartConversation(int idSender, int idReceiver)
        {
            try
            {
                ConversationDto conversation = _chatService.CreateConversation(idSender, idReceiver);
                return Ok(conversation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Une erreur est survenue lors de la création de la conversation");
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ConversationDto> LoadConversation(int id)
        {
            try
            {
                var conversation = _chatService.LoadConversation(id);
                return Ok(conversation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur est survenue lors du chargement de la conversation");
                throw;
            }
        }

        [HttpPost("{id}/messages")]
        public ActionResult<MessageDto> SendMessageAsync(int id, int senderId, string message)
        {
            try
            {
                var newMessage = _chatService.SendMessage(id, senderId, message);
                return Ok(newMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur est survenu lors de l'envoi du message");
            }
        }
    }
}

using ChatRoomApi.Models;
using ChatRoomApi.Models.Dtos.ChatRoom;
using ChatRoomApi.Models.Dtos.Messages;
using ChatRoomApi.Models.Dtos.User;
using ChatRoomApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ChatRoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatRoomRepository ChatRoomRepository { get; set; }
        private IConnectionsRepository ConnectionsRepository { get; set; }

        public ChatController(IChatRoomRepository chatRoomRepository, IConnectionsRepository connectionsRepository)
        {
            ChatRoomRepository = chatRoomRepository;
            ConnectionsRepository = connectionsRepository;
        }

        [HttpPost]
        public IActionResult Create(ChatRoomRequestDto chatroom)
        {
            if (ChatRoomRepository.GetByName(chatroom.Name) != null)
                return new ConflictObjectResult($"Room with name {chatroom.Name} already exists");

            var newChatRoom = new ChatRoom
            {
                Name = chatroom.Name,
                Status = "live"
            };

            ChatRoomRepository.Create(newChatRoom);

            return new OkObjectResult(new ChatRoomResponseDto(newChatRoom));
        }

        [HttpGet("")]
        public IActionResult GetById([FromQuery(Name = "id")] int id)
        {
            if (id == 0) return new NotFoundObjectResult("Cannot resolve this url");

            var chatRoom = ChatRoomRepository.GetById(id);
            if (chatRoom == null) return new NotFoundObjectResult($"Cannot find chat room with id {id}");

            return new OkObjectResult(new ChatRoomResponseDto(chatRoom));
        }

        [HttpDelete]
        public IActionResult DeleteById([FromQuery(Name = "id")] int id)
        {
            if (id == 0) return new NotFoundObjectResult("Cannot resolve this url");

            var chatRoom = ChatRoomRepository.GetById(id);
            if (chatRoom == null) return new NotFoundObjectResult($"Cannot find chat room with id {id}");

            ChatRoomRepository.Delete(chatRoom);
            return new OkObjectResult(new ChatRoomResponseDto(chatRoom));
        }

        [HttpPost("join")]
        public IActionResult JoinChat([FromQuery(Name = "id")] int id, [FromBody] UserRequestDto user)
        {
            if (id == 0) return new NotFoundObjectResult("Cannot resolve this url");

            var chatRoom = ChatRoomRepository.GetById(id);
            if (chatRoom == null) return new NotFoundObjectResult($"Cannot find chat room with id {id}");

            var existingUser = chatRoom.Users.FirstOrDefault(x => x.UserName == user.Name);
            if (existingUser != null) return new ConflictObjectResult($"User with name {user.Name} already in room");

            chatRoom.Users.Add(new Connection
            {
                UserName = user.Name,
            });

            ChatRoomRepository.Save();

            return new OkResult();
        }

        [HttpPost("ws")]
        public IActionResult SendMessage([FromQuery(Name = "id")] int id, [FromBody] MessageRequestDto message)
        {
            if (id == 0) return new NotFoundObjectResult("Cannot resolve this url");

            var chatRoom = ChatRoomRepository.GetById(id);
            if (chatRoom == null) return new NotFoundObjectResult($"Cannot find chat room with id {id}");

            var existingUser = chatRoom.Users.FirstOrDefault(x => x.UserName == message.Name);
            if (existingUser == null) return new NotFoundObjectResult($"User with name {message.Name} not found in chat with id = {id}");

            var hubMessage = new MessageResponseDto
            {
                Name = existingUser.UserName,
                Message = message.Message,
                Time = DateTime.Now
            };

            // TODO: Add SignalR to send a messages to client
            return new OkObjectResult(hubMessage);
        }

        [HttpDelete("ws")]
        public IActionResult Exit([FromQuery(Name = "id")] int id, [FromBody] UserRequestDto user)
        {
            if (id == 0) return new NotFoundObjectResult("Cannot resolve this url");

            var chatRoom = ChatRoomRepository.GetById(id);
            if (chatRoom == null) return new NotFoundObjectResult($"Cannot find chat room with id {id}");

            var existingUser = chatRoom.Users.FirstOrDefault(x => x.UserName == user.Name);
            if (existingUser == null) return new NotFoundObjectResult($"User with name {user.Name} not found in chat with id = {id}");

            ConnectionsRepository.DeleteUserFromChat(user.Name, chatRoom);
            return new OkResult();
        }
    }
}
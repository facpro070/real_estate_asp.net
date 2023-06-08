﻿using ContractsMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        private readonly ILogger<NoteController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public NoteController(
            INoteService noteService,
            ILogger<NoteController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        [HttpGet]
        public IActionResult GetNotesList(int userId)
        {
            try
            {
                var notes = _noteService.GetNotesList(userId);
                return Ok(notes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int userId, int noteId)
        {
            try
            {
                // Check if the user has the note
                bool hasNote = await _noteService.CheckIfUserHasNote(userId, noteId);
                if (!hasNote)
                {
                    throw new Exception("The user does not have this note");
                }

                // Delete the note
                // (Implementation details will depend on the specific storage system being used)
                await _noteService.DeleteNote(userId, noteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                // (Implementation details will depend on the specific logging system being used)

                // Return an error response to the client
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> CheckIfUserHasNote(int userId, int noteId)
        {
            try
            {
                bool result = await _noteService.CheckIfUserHasNote(userId, noteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult ValidateNote(Note model)
        {
            try
            {
                _noteService.ValidateModel(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public string GetContentType(string fileName)
        {
            try
            {
                var mimeType = GetContentTypeUtil();
                if (string.IsNullOrEmpty(mimeType))
                {
                    throw new Exception($"Could not determine MIME type for file '{fileName}'");
                }

                return mimeType;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error getting content type for file '{fileName}': {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        // http://localhost:9002/api/note/gethealth
        // http://localhost:9000/api/note/gethealth behind gateway
        public string getHealth() => "Contracts Microservice up and running";

        static string GetContentTypeUtil()
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }
    }
}

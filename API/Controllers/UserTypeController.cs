﻿using BLL.Services;
using DATA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public UserTypeController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        // GET: /user_types
        [HttpGet("user_types")]
        public ActionResult<List<PlantDto>> GetAllPlants()
        {
            try
            {
                var plants = _plantService.GetAllPlants();
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /user_type/{id}
        [HttpGet("{id}")]
        public ActionResult<PlantDto> GetPlantById(int id)
        {
            try
            {
                var plant = _plantService.GetPlantById(id);
                if (plant == null)
                {
                    return NotFound();
                }
                return Ok(plant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: /user_type
        [HttpPost]
        public ActionResult<PlantDto> CreatePlant(PlantDto plantDto)
        {
            try
            {
                var createdPlant = _plantService.CreatePlant(plantDto);
                return CreatedAtAction(nameof(GetPlantById), new { id = createdPlant.IdPlant }, createdPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: /user_type/{id}
        [HttpPut("{id}")]
        public ActionResult<PlantDto> UpdatePlant(int id, PlantDto plantDto)
        {
            try
            {
                if (plantDto.IdPlant != id)
                {
                    return BadRequest("Invalid ID provided");
                }

                var updatedPlant = _plantService.UpdatePlant(plantDto);
                if (updatedPlant == null)
                {
                    return NotFound();
                }

                return Ok(updatedPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: /user_type/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            try
            {
                _plantService.DeletePlant(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

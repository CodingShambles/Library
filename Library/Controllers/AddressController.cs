using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public AddressController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllAddresses()
    {
        try
        {
            var addresses = _repository.Address.GetAllAddresses();
            _logger.LogInfo($"Returned all addresses stored on database.");

            var addressResult = _mapper.Map<IEnumerable<AddressDto>>(addresses);

            return Ok(addressResult);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Something is not working properly inside GetAllAddresses action: {ex.Message}");
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(Guid id)
    {
        try
        {
            var address = _repository.Address.GetAddressById(id);

            if (address is null)
            {
                _logger.LogError($"The address related to Id {id} has not been found in database.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Returned Address with Id: {id}");
                return Ok(address);
            }
        }
        catch(Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetAddressById Action: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}/person")]
    public IActionResult GetAddressWithDetails(Guid id)
    {
        try
        {
            var address = _repository.Address.GetAddressWithDetails(id);

            if(address is null)
            {
                _logger.LogError($"Address with Id: {id} has not been found in database.");
                return NotFound();
            }

            else
            {
                _logger.LogInfo($"Returned address with details for id: {id}");

                var addressResult = _mapper.Map<AddressDto>(address);
                return Ok(addressResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetAddressWithDetails Action: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public IActionResult CreateAddress([FromBody] AddressDto addressDto)
    {
        try
        {
            if(addressDto == null)
            {
                _logger.LogError("Address object sent from client is null.");
                return BadRequest("Address object is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid address object sent from client.");
                return BadRequest("Invalid Model Object.");
            }

            var addressEntity = _mapper.Map<Address>(addressDto);

            _repository.Address.CreateAddress(addressEntity);
            _repository.Save();

            var createdAddress = _mapper.Map<AddressDto>(addressEntity);

            return CreatedAtRoute("AddressById", createdAddress);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Somthing went wrong inside CreateAddress action: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
}

using PersonDirectory.Application.Models;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Interfaces;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(ILogger<PersonController> logger,
    IPersonService personService, IFileService fileService, IStringLocalizer<SharedValidatorResources> localizer) : ControllerBase
{
    private readonly IPersonService _personService = personService;
    private readonly IFileService _fileService = fileService;
    private readonly ILogger<PersonController> _logger = logger;

    #region person_methods
    /// <summary>
    /// Create person
    /// </summary>
    /// <param name="person">request model</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>created object</returns>
    /// <response code="201">Person is created</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] PersonPostDto person, CancellationToken cancellationToken)
    {
        try
        {
            var createdItem = await _personService.Create(person, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);  // 201 Created
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Update person
    /// </summary>
    /// <param name="id">person id</param>
    /// <param name="person">person model</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <response code="204">Person is updated</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] PersonPutDto person, CancellationToken cancellationToken)
    {
        try
        {
            await _personService.Update(id, person, cancellationToken);

            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Delete person
    /// </summary>
    /// <param name="id">person id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <response code="204">Person is deleted</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _personService.Delete(id, cancellationToken);
        if (!isDeleted)
        {
            return NotFound(localizer["Notfound"]);
        }

        return NoContent();
    }

    /// <summary>
    /// Get person by id
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>person</returns>
    /// <response code="200">Person is found</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await _personService.GetById(id, cancellationToken);
        if (entity == null)
        {
            return NotFound(localizer["Notfound"]);
        }
        return Ok(entity);
    }
    #endregion

    #region person_connection_methods
    /// <summary>
    /// Connect person to other person
    /// </summary>
    /// <param name="connectionDto">request model</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>connectin model</returns>
    /// <response code="200">Connection is created</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("connection")]
    public async Task<ActionResult<ConnectionDto>> Createconnection(ConnectionRequestDto connectionDto, CancellationToken cancellationToken)
    {
        try
        {
            var createdItem = await _personService.CreateConnectionAsync(connectionDto, cancellationToken);
            return CreatedAtAction(nameof(Createconnection), new { id = createdItem.Id }, createdItem);  // 201 Created
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Remove person connection
    /// </summary>
    /// <param name="id">id of connection</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>operation result</returns>
    /// <response code="204">Connection is deleted</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("connection")]
    public async Task<ActionResult> RemoveConnection(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _personService.RemoveConnection(id, cancellationToken);
        if (!isDeleted)
        {
            return NotFound(localizer["Notfound"]);
        }

        return NoContent();
    }
    #endregion

    #region person_additional_methods
    /// <summary>
    /// Upload person photo
    /// </summary>
    /// <param name="file">photo file</param>
    /// <param name="personId">person id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>person model</returns>
    /// <response code="200">Photo is uploaded</response>
    /// <response code="400">Error while processing</response>
    /// <response code="404">Object cannot be found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("{personId}/image")]
    public async Task<ActionResult<PersonDto>> UploadImage(IFormFile file, int personId, CancellationToken cancellationToken)
    {
        var ImageUrl = await _fileService.UploadFileAsync(file, localizer, cancellationToken);
        try
        {
            return Ok(await _personService.UpdateImageAsync(personId, ImageUrl, cancellationToken));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Detailed search with pagination
    /// </summary>
    /// <param name="paginationParams">pagination parameters</param>
    /// <param name="searchRequest">search request</param>
    /// <returns>search result</returns>
    /// <response code="200">Search is successful</response>
    /// <response code="400">Error while processing</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("DetailedSearch/")]
     public async Task<ActionResult<PagedResponseDto<PersonDto>>>GetPersonDetailedSearch(
        [FromQuery] PaginationParams paginationParams,
        [FromQuery] PersonSearchRequestDto searchRequest)
    {
        var result = await _personService.DetailedSearchAsync(paginationParams, searchRequest);
        return Ok(result);
    }

    /// <summary>
    /// Search people by keyword in several fields
    /// </summary>
    /// <param name="searchString">search string</param>
    /// <param name="cancellationToken">cancellatin token</param>
    /// <returns></returns>
    /// <returns>search result</returns>
    /// <response code="200">Search is successful</response>
    /// <response code="400">Error while processing</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("Search/{searchString}")]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Search(string searchString, CancellationToken cancellationToken)
    {
        return Ok(await _personService.Search(searchString, cancellationToken));
    }

    /// <summary>
    /// Report of people connections
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>report</returns>
    /// <response code="200">Report generation is successful</response>
    /// <response code="400">Error while processing</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("PersonConnectionsReport/")]
    public async Task<ActionResult<Dictionary<int, PersonConnectionsReportDto>>> GetConnectionsByType(CancellationToken cancellationToken)
    {
        return Ok(await _personService.GetPersonConnectionsTypeCounts(cancellationToken));
    }    
    #endregion
}
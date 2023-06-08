using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
// alternatively you can use a common route string with [Route("[controller]")] 
// it will use name of class minus controller
public class BreakfastsController : Controller{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService){
        _breakfastService = breakfastService;
    }
    
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        // TODO: save to database
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new {id = breakfast.Id},
            response);  
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
        Breakfast breakfast = _breakfastService.GetBreakfast(id);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request){
        var breakfast = new Breakfast(
            id, 
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _breakfastService.UpsertBreakfast(breakfast);
        //TODO: return new breakfast if id is new
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }

}
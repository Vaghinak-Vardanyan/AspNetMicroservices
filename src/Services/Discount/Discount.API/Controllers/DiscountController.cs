﻿using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _repository;

    public DiscountController(IDiscountRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet("{productName}", Name = nameof(GetDiscount))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Coupon>> GetDiscount(string productName)
    {
        var coupon = await _repository.GetDiscount(productName);
        return Ok(coupon);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Coupon>> CreatesDisount([FromBody] Coupon coupon)
    {
        await _repository.CreateDiscount(coupon);
        return CreatedAtRoute(nameof(GetDiscount), new { productName = coupon.ProductName }, coupon);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Coupon>> UpdateDisount([FromBody] Coupon coupon)
    {
        return Ok(await _repository.UpdateDiscount(coupon));
    }

    [HttpDelete("{productName}", Name = nameof(DeleteDiscount))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> DeleteDiscount(string productName)
    {
        return Ok(await _repository.DeleteDiscount(productName));
    }

}


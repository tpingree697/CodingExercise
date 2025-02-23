﻿using InvestmentPerformanceApi.Data;
using InvestmentPerformanceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System;
using System.Linq;
using System.Text.Json;
using InvestmentPerformanceApi.Services;

namespace InvestmentPerformanceApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentPerformanceController : ControllerBase
    {
        private readonly IInvestmentService _service;

        public InvestmentPerformanceController(IInvestmentService service)
        {
            _service = service;
        }

        [HttpGet("getUserInvestments/{userId}")]
        public async Task<ActionResult> GetUserInvestments(int userId)
        {
            var userInvestment = await _service.getUserInvestmentsAsync(userId);

            if (userInvestment == null)
            {
                return BadRequest("The userId provided could not be found.");
            }

            return Ok(userInvestment);
        }

        [HttpGet("getInvestmentDetails/{userId:int}/{investmentId:int}")]
        public async Task<ActionResult<Investment>> GetInvestmentDetails(int userId, int investmentId)
        {
            var investment = await _service.getInvestmentDetails(userId, investmentId);
            
            if (investment == null)
            {
                return BadRequest("The userId or investmentId provided cannot be found.");   
            }

            return Ok(investment);
        }

    }
}
using backend.Models;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService service)
        {
            _walletService = service;
        }

        [HttpGet] 
        public async Task<ActionResult> GetWallets()
        {            
            try
            {
                var wallets = await _walletService.GetAllWallets();
                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpGet("{usuarioid}")]
        public async Task<ActionResult> GetWallets(int usuarioid)
        {
            try
            {
                var wallets = await _walletService.GetWalletsByUserId(usuarioid);
                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Wallet wallet)
        {
            try
            {
                if (wallet == null)
                {
                    return BadRequest();
                }
                await _walletService.AddWallet(wallet);
                return Ok(wallet.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {               
                await _walletService.DeleteWalletById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

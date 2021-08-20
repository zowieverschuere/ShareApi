using Microsoft.AspNetCore.Mvc;
using ShareApi.DTOs;
using ShareApi.Models;
using System.Collections.Generic;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SharesController : Controller
    {
        private readonly IShareRepository _shareRepository;

        public SharesController(IShareRepository context)
        {
            _shareRepository = context;
        }

        /// <summary>
        ///  Get all shares
        /// </summary>
        /// <returns>All shares</returns>
        [HttpGet]
        public IEnumerable<Share> GetShares()
        {
            IEnumerable<Share> shares = _shareRepository.GetAll();
            if (shares == null)
            {
                return _shareRepository.GetAll();
            }
            return shares;
        }


        /// <summary>
        /// Gives the share with given id
        /// </summary>
        /// <param name="id">this is the id of the share</param>
        /// <returns>The share</returns>
        [HttpGet("{id}")]
        public ActionResult<Share> GetShare(int id)
        {
            Share share = _shareRepository.GetBy(id);
            if (share == null)
                return NotFound();
            return share;
        }

        /// <summary>
        /// Adds a new share 
        /// </summary>
        /// <param name="share"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Share> PostShare(ShareDTO share)
        {
            Share shareToCreate = new Share() { Name = share.Name, StockName = share.StockName, BuyPrice = share.BuyPrice, Discription = share.Discription };
            _shareRepository.Add(shareToCreate);
            _shareRepository.SaveChanges();

            return CreatedAtAction(nameof(GetShare), new { id = shareToCreate.Id }, shareToCreate);
        }


        /// <summary>
        /// Deletes a share
        /// </summary>
        /// <param name="id">The id of the share that needs to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteShare(int id)
        {
            Share deleteShare = _shareRepository.GetBy(id);
            if (deleteShare == null)
            {
                return NotFound();
            }
            _shareRepository.Delete(deleteShare);
            _shareRepository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// updates a share with the given information
        /// </summary>
        /// <param name="id">The id of the share that has to be updated</param>
        /// <param name="share">The updated share</param>
        /// <returns>Updated share</returns>
        [HttpPut("{id}")]
        public IActionResult PutShare(int id, Share share)
        {
            if (id != share.Id)
            {
                return BadRequest("Id didn't match");

            }
            _shareRepository.Update(share);
            _shareRepository.SaveChanges();

            return NoContent();
        }




    }
}

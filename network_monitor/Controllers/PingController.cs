using Microsoft.AspNetCore.Mvc;
using network_monitor.Models;
using System.Net;
using System.Net.NetworkInformation;

namespace network_monitor.Controllers
{
    public class PingController : Controller
    {
        public IActionResult Ping(string address = null)
        {
            if (string.IsNullOrEmpty(address))
            {
                // Render the form without errors on initial load.
                return View();
            }

            if (!IsValidAddress(address))
            {
                ModelState.AddModelError("", "Invalid IP address or hostname.");
                return View();
            }

            try
            {
                var ping = new Ping();
                var reply = ping.Send(address);

                var result = new PingResults
                {
                    Address = address,
                    RoundTripTime = reply.RoundtripTime,
                    Status = reply.Status.ToString()
                };

                return View(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View();
            }
        }

        private bool IsValidAddress(string address)
        {
            return Uri.CheckHostName(address) != UriHostNameType.Unknown;
        }
    }
}

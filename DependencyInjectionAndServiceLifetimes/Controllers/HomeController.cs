using Microsoft.AspNetCore.Mvc;
using System.Text;
using DependencyInjectionAndServiceLifetimes.Interfaces;

namespace DependencyInjectionAndServiceLifetimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExampleTransientService _exampleTransientService1;
        private readonly IExampleTransientService _exampleTransientService2;
        private readonly IExampleTransientService _exampleTransientService3;

        private readonly IExampleScopedService _exampleScopedService1;
        private readonly IExampleScopedService _exampleScopedService2;
        private readonly IExampleScopedService _exampleScopedService3;

        private readonly IExampleSingletonService _exampleSingletonService1;
        private readonly IExampleSingletonService _exampleSingletonService2;
        private readonly IExampleSingletonService _exampleSingletonService3;

        public HomeController(IExampleTransientService exampleTransientService1,
            IExampleTransientService exampleTransientService2,
            IExampleTransientService exampleTransientService3,
            IExampleScopedService exampleScopedService1,
            IExampleScopedService exampleScopedService2,
            IExampleScopedService exampleScopedService3,
            IExampleSingletonService exampleSingletonService1,
            IExampleSingletonService exampleSingletonService2,
            IExampleSingletonService exampleSingletonService3)
        {
            _exampleTransientService1 = exampleTransientService1;
            _exampleTransientService2 = exampleTransientService2;
            _exampleTransientService3 = exampleTransientService3;

            _exampleScopedService1 = exampleScopedService1;
            _exampleScopedService2 = exampleScopedService2;
            _exampleScopedService3 = exampleScopedService3;

            _exampleSingletonService1 = exampleSingletonService1;
            _exampleSingletonService2 = exampleSingletonService2;
            _exampleSingletonService3 = exampleSingletonService3;
        }

        public IActionResult Index()
        {
            var exampleTransientServiceGuid1 = _exampleTransientService1.GetGuid();
            var exampleTransientServiceGuid2 = _exampleTransientService2.GetGuid();
            var exampleTransientServiceGuid3 = _exampleTransientService3.GetGuid();

            var exampleScopedServiceGuid1 = _exampleScopedService1.GetGuid();
            var exampleScopedServiceGuid2 = _exampleScopedService2.GetGuid();
            var exampleScopedServiceGuid3 = _exampleScopedService3.GetGuid();

            var exampleSingletonServiceGuid1 = _exampleSingletonService1.GetGuid();
            var exampleSingletonServiceGuid2 = _exampleSingletonService2.GetGuid();
            var exampleSingletonServiceGuid3 = _exampleSingletonService3.GetGuid();

            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1: {exampleTransientServiceGuid1}\n");
            messages.Append($"Transient 2: {exampleTransientServiceGuid2}\n");
            messages.Append($"Transient 3: {exampleTransientServiceGuid3}\n\n");

            messages.Append($"Scoped 1: {exampleScopedServiceGuid1}\n");
            messages.Append($"Scoped 2: {exampleScopedServiceGuid2}\n");
            messages.Append($"Scoped 3: {exampleScopedServiceGuid3}\n\n");

            messages.Append($"Singleton 1: {exampleSingletonServiceGuid1}\n");
            messages.Append($"Singleton 2: {exampleSingletonServiceGuid2}\n");
            messages.Append($"Singleton 3: {exampleSingletonServiceGuid3}");

            return Ok(messages.ToString());
        }
    }
}
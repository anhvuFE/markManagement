using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string AsciiArt { get; set; }

        public void OnGet()
        {
            var asciiArts = new List<string>
            {
                @"
?  ╱|、
(˚ˎ 。7  
        |、˜〵          
じしˍ,)ノ
                ",
                @"
 /\\_/\\
( o.o )
 > ^ <
                ",
                @"
 / \__
(    @\___
 /         O
/   (_____/
/_____/ U
                ",
                @"
  _~_
 (o o)
/  V  \\
/(   )\\
 ^-^-^
                ",
                @"
 (\(\ 
 ( -.-)
 o_(\)(\)
                ",
                @"
  _  
<(o )___
 (    ___)
  (___)
                "
            };

            var random = new Random();
            int index = random.Next(asciiArts.Count);
            AsciiArt = asciiArts[index];
        }
    }
}

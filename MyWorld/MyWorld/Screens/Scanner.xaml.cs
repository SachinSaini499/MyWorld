using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;

namespace MyWorld.Screens
{
    public partial class Scanner : ContentPage
    {
        public Scanner()
        {
            InitializeComponent();
        }

      async  private void btnBarCode_Clicked(object sender, EventArgs e)
        {

	// Initialize the scanner first so it can track the current context
	       //  MobileBarcodeScanner.Initialize (Application);


            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            scanner.ToggleTorch();
            scanner.Torch(true);
            
             var result = await scanner.Scan();

            if (result != null)
                lblScanInfo.Text = result.Text;
        }
    }
}

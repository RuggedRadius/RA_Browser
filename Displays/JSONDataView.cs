using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API
{
    public partial class JSONDataView : Form
    {
        string formattedJSON;

        public JSONDataView(JObject data)
        {
            InitializeComponent();
            formattedJSON = JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        private void JSONDataView_Load(object sender, EventArgs e)
        {
            txtJSONView.Text = formattedJSON;
        }
    }
}

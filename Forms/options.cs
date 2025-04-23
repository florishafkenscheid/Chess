using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using ChessApp.Services;
using ChessApp.Utils;

namespace ChessApp
{
    public partial class Options : Form
    {
        private bool isConfiguring = false;

        public Options()
        {
            InitializeComponent();
            ConfigureSystemLimits();
            ramNumericUpDown.ValueChanged += RamNumericUpDown_ValueChanged;
        }

        private void ConfigureSystemLimits()
        {
            try
            {
                isConfiguring = true;

                // Threads
                int maxThreads = Environment.ProcessorCount;
                threadsNumericUpDown.Minimum = 1;
                threadsNumericUpDown.Maximum = maxThreads;

                // RAM
                var compInfo = new ComputerInfo();
                long totalMB = (long)(compInfo.TotalPhysicalMemory / (1024 * 1024));
                long safeMaxRam = (long)(totalMB * 0.9);
                long minRamMB = 256;

                ramNumericUpDown.Minimum = minRamMB;
                ramNumericUpDown.Maximum = Math.Max(safeMaxRam, minRamMB);
                ramNumericUpDown.Value = Math.Min(2048, ramNumericUpDown.Maximum);

                // Hash (same as RAM for now)
                ramNumericUpDown.Minimum = 1;
                ramNumericUpDown.Maximum = ramNumericUpDown.Value;
                ramNumericUpDown.Value = Math.Min(1024, ramNumericUpDown.Maximum);
            }
            finally
            {
                isConfiguring = false;
            }
        }

        private void RamNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isConfiguring) return;

            ramNumericUpDown.Maximum = ramNumericUpDown.Value;

            if (ramNumericUpDown.Value > ramNumericUpDown.Maximum)
            {
                ramNumericUpDown.Value = ramNumericUpDown.Maximum;
            }
        }

        private void RoundButton1_Click(object sender, EventArgs e)
        {
            // Create and configure EngineOption instances
            var options = new[]
            {
                new EngineOption { Name = "Skill Level", Value = SkillLevelNumup.Value.ToString() },
                new EngineOption { Name = "Threads", Value = threadsNumericUpDown.Value.ToString() },
                new EngineOption { Name = "Hash", Value = ramNumericUpDown.Value.ToString() }
            };

            // Serialize all options
            Serializer.Write(options);

            this.Close();
        }
    }

    struct EngineOption
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using ChessApp.Services;

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

        private async void roundButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int skillLevel = (int)SkillLevelNumup.Value;
                int threads = (int)threadsNumericUpDown.Value;
                int hash = (int)ramNumericUpDown.Value;

                await Task.Run(async () =>
                {
                    using var stockfishService = new StockfishService();
                    if (await stockfishService.IsReady())
                    {
                        try { await stockfishService.SetOption("Skill Level", skillLevel.ToString()); }
                        catch (Exception ex) { MessageBox.Show("Skill Level failed:\n" + ex.Message); }

                        try { await stockfishService.SetOption("Threads", threads.ToString()); }
                        catch (Exception ex) { MessageBox.Show("Threads failed:\n" + ex.Message); }

                        try { await stockfishService.SetOption("Hash", hash.ToString()); }
                        catch (Exception ex) { MessageBox.Show("Hash failed:\n" + ex.Message); }
                    }
                });

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outer Error:\n" + ex.Message);
            }
        }

    }
}

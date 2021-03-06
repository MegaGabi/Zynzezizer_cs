﻿using System;
using System.Windows.Forms;

namespace Zynzezizer_cs
{
    public partial class Synthesizers : Form
    {
        private SynthEngine synthEngine;
        private NoiseMakingUtils noiseMakingUtils;

        public Synthesizers(SynthEngine synthEngine)
        {
            InitializeComponent();
            noiseMakingUtils = new NoiseMakingUtils();
            this.synthEngine = synthEngine;

            Osc1_waveform.SelectedIndex = 0;
            Osc2_waveform.SelectedIndex = 0;
            Osc3_waveform.SelectedIndex = 0;

            LFO_Waveform.SelectedIndex = 0;

            FilterType.SelectedIndex = 0;
        }

        private Func<float, float> getWaveFunction()
        {
            if (rb_Oscillators.Checked)
            {
                MixInfo[] mixInfo = new MixInfo[3];

                if (Osc1_waveform.SelectedItem == null)
                {
                    mixInfo[0].function = noiseMakingUtils.getFunctionByType(NoiseMakingUtils.WaveForms.Sine);
                }
                else
                {
                    mixInfo[0].function = noiseMakingUtils.getFunctionByName(Osc1_waveform.SelectedItem.ToString());
                }
                mixInfo[0].mix = 1;
                mixInfo[0].fine = tb_Osc1_Fine.Value;
                mixInfo[1].semi = 0;

                if (Osc2_waveform.SelectedItem == null)
                {
                    mixInfo[1].function = noiseMakingUtils.getFunctionByType(NoiseMakingUtils.WaveForms.Sine);
                }
                else
                {
                    mixInfo[1].function = noiseMakingUtils.getFunctionByName(Osc2_waveform.SelectedItem.ToString());
                }
                mixInfo[1].mix = tb_Osc2_Mix.Value / 100f;
                mixInfo[1].fine = tb_Osc2_Fine.Value;
                mixInfo[1].semi = tb_Osc2_Semi.Value;

                if (Osc3_waveform.SelectedItem == null)
                {
                    mixInfo[2].function = noiseMakingUtils.getFunctionByType(NoiseMakingUtils.WaveForms.Sine);
                }
                else
                {
                    mixInfo[2].function = noiseMakingUtils.getFunctionByName(Osc3_waveform.SelectedItem.ToString());
                }
                mixInfo[2].mix = tb_Osc3_Mix.Value / 100f;
                mixInfo[2].fine = tb_Osc3_Fine.Value;
                mixInfo[2].semi = tb_Osc3_Semi.Value;

                if (LFO_Waveform.SelectedItem == null)
                {
                    synthEngine.LFOFunction = noiseMakingUtils.getFunctionByType(NoiseMakingUtils.WaveForms.Sine);
                }
                else
                {
                    synthEngine.LFOFunction = noiseMakingUtils.getFunctionByName(LFO_Waveform.SelectedItem.ToString());
                }

                synthEngine.LFOAmplitude = LFO_Frequency.Value;
                synthEngine.LFOAmplitude = LFO_Volume.Value / 1000f;

                return noiseMakingUtils.getAdditiveMixedFunction(mixInfo);
            }
            else
            {
                try
                {
                    return noiseMakingUtils.getFunctionFromString(tb_Formula.Text);
                }
                catch
                {
                    MessageBox.Show("Can't parse formula!", "Error!");
                }

                return noiseMakingUtils.getFunctionByType(NoiseMakingUtils.WaveForms.Sine);
            }
        }

        private void Osc1_waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void Osc2_waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void Osc3_waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void Synthesizers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void tb_Osc1_Fine_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc1_Fine.Text = tb_Osc1_Fine.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }
        private void tb_Osc2_Mix_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc2_Mix.Text = tb_Osc2_Mix.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void tb_Osc2_Fine_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc2_Fine.Text = tb_Osc2_Fine.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void tb_Osc2_Semi_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc2_Semi.Text = tb_Osc2_Semi.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void tb_Osc3_Mix_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc3_Mix.Text = tb_Osc3_Mix.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void tb_Osc3_Fine_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc3_Fine.Text = tb_Osc3_Fine.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void tb_Osc3_Semi_ValueChanged(object sender, EventArgs e)
        {
            lbl_Osc3_Semi.Text = tb_Osc3_Semi.Value.ToString();
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void AMP_Attack_Scroll(object sender, EventArgs e)
        {
            synthEngine.Attack = AMP_Attack.Value / 1000.0f;
            lbl_AMP_Attack.Text = (AMP_Attack.Value / 1000.0f).ToString("n3") + "s";
        }

        private void AMP_Decay_Scroll(object sender, EventArgs e)
        {
            synthEngine.Decay = AMP_Decay.Value / 1000.0f;
            lbl_AMP_Decay.Text = (AMP_Decay.Value / 1000.0f).ToString("n3") + "s";
        }

        private void AMP_Sustain_Scroll(object sender, EventArgs e)
        {
            synthEngine.Sustain = AMP_Sustain.Value / 100.0f;
            lbl_AMP_Sustain.Text = AMP_Sustain.Value + "%";
        }

        private void AMP_Release_Scroll(object sender, EventArgs e)
        {
            synthEngine.Release = AMP_Release.Value / 1000.0f;
            lbl_AMP_Release.Text = (AMP_Release.Value / 1000.0f).ToString("n3") + "s";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var plotter = new Plotter(getWaveFunction());
            plotter.MdiParent = this.MdiParent;
            plotter.Show();
        }

        private void UpdateFilter()
        {
            switch (FilterType.SelectedText)
            {
                case "Low pass":
                    synthEngine.FilterMode = FilterMode.LowPass;
                    return;
                case "High pass":
                    synthEngine.FilterMode = FilterMode.HighPass;
                    return;
                case "Band pass":
                    synthEngine.FilterMode = FilterMode.BandPass;
                    return;
            }
            synthEngine.FilterAttack = Filter_Attack.Value / 1000f;
            synthEngine.FilterDecay = Filter_Decay.Value / 1000f;
            synthEngine.FilterSustain = Filter_Sustain.Value / 100.0f;
            synthEngine.FilterRelease = Filter_Release.Value / 1000f;
            synthEngine.FilterCutoff = Filter_Cutoff.Value;
            synthEngine.FilterEnvelopeOctaves = Filter_Envelope_Octaves.Value / 100.0f;
        }

        private void FilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void Filter_Attack_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_Attack.Text = (Filter_Attack.Value / 1000.0f).ToString("n3") + "s";
        }

        private void Filter_Decay_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_Decay.Text = (Filter_Decay.Value / 1000.0f).ToString("n3") + "s";
        }

        private void Filter_Sustain_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_Sustain.Text = Filter_Sustain.Value.ToString() + "%";
        }

        private void Filter_Release_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_Release.Text = (Filter_Release.Value / 1000.0f).ToString("n3") + "s";
        }

        private void Filter_Cutoff_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_Cutoff.Text = Filter_Cutoff.Value.ToString();
        }

        private void cb_FilterBypass_CheckedChanged(object sender, EventArgs e)
        {
            synthEngine.FilterLevel = cb_FilterBypass.Checked ? 0 : 1;
        }

        private void tb_Volume_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.Amplitude = tb_Volume.Value / 1000.0f;
            lbl_Volume.Text = tb_Volume.Value.ToString() + "%";
        }

        private void Filter_Envelope_Octaves_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
            lbl_Filter_FEO.Text = (Filter_Envelope_Octaves.Value / 100.0f).ToString();
        }

        private void LFO_Frequency_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
            lbl_LFO_Frequency.Text = LFO_Frequency.Value.ToString();
        }

        private void LFO_Volume_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
            lbl_LFO_Amplitude.Text = LFO_Volume.Value.ToString() + "%";
        }

        private void LFO_Waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void Reverb_Level_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.ReverbLevel = Reverb_Level.Value / 1000f;
            lbl_Reverb_Level.Text = synthEngine.ReverbLevel.ToString("n3");
        }

        private void Reverb_Damp_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.ReverbDamping = Reverb_Damp.Value / 1000f;
            lbl_Reverb_Damp.Text = synthEngine.ReverbDamping.ToString("n3");
        }

        private void Reverb_Room_ValueChanged(object sender, EventArgs e)
        {
            synthEngine.ReverbRoomSize = Reverb_Room.Value / 1000f;
            lbl_Reverb_Room.Text = synthEngine.ReverbRoomSize.ToString("n3");
        }

        private void btn_Formula_Done_Click(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        private void rb_Oscillators_CheckedChanged(object sender, EventArgs e)
        {
            synthEngine.WaveformFunction = getWaveFunction();
        }

        public SynthesizersData serialize()
        {
            SynthesizersData result = new SynthesizersData();
            result.osc1_Index = Osc1_waveform.SelectedIndex;
            result.osc1_Fine = tb_Osc1_Fine.Value;

            result.osc2_Index = Osc2_waveform.SelectedIndex;
            result.osc2_Mix = tb_Osc2_Mix.Value;
            result.osc2_Fine = tb_Osc2_Fine.Value;
            result.osc2_Semi = tb_Osc2_Semi.Value;

            result.osc3_Index = Osc3_waveform.SelectedIndex;
            result.osc3_Mix = tb_Osc3_Mix.Value;
            result.osc3_Fine = tb_Osc3_Fine.Value;
            result.osc3_Semi = tb_Osc3_Semi.Value;

            result.isUsingFormula = rb_Formula.Checked;

            result.formula = tb_Formula.Text;

            result.volume = tb_Volume.Value;

            result.amp_attack = AMP_Attack.Value;
            result.amp_decay = AMP_Decay.Value;
            result.amp_sustain = AMP_Sustain.Value;
            result.amp_release = AMP_Release.Value;

            result.filter_index = FilterType.SelectedIndex;
            result.isBypass = cb_FilterBypass.Checked;
            result.filter_cutoff = Filter_Cutoff.Value;
            result.filter_FEO = Filter_Envelope_Octaves.Value;
            result.filter_attack = Filter_Attack.Value;
            result.filter_decay = Filter_Decay.Value;
            result.filter_sustain = Filter_Sustain.Value;
            result.filter_release = Filter_Release.Value;

            result.lfo_index = LFO_Waveform.SelectedIndex;
            result.lfo_frequency = LFO_Frequency.Value;
            result.lfo_amplitude = LFO_Volume.Value;

            result.reverb_level = Reverb_Level.Value;
            result.reverb_damp = Reverb_Damp.Value;
            result.reverb_room = Reverb_Room.Value;
            return result;
        }

        public void LoadFromData(SynthesizersData synthesizersData)
        {
            Osc1_waveform.SelectedIndex = synthesizersData.osc1_Index;
            tb_Osc1_Fine.Value = synthesizersData.osc1_Fine;

            Osc2_waveform.SelectedIndex = synthesizersData.osc2_Index;
            tb_Osc2_Mix.Value = synthesizersData.osc2_Mix;
            tb_Osc2_Fine.Value = synthesizersData.osc2_Fine;
            tb_Osc2_Semi.Value = synthesizersData.osc2_Semi;

            Osc3_waveform.SelectedIndex = synthesizersData.osc3_Index;
            tb_Osc3_Mix.Value = synthesizersData.osc3_Mix;
            tb_Osc3_Fine.Value = synthesizersData.osc3_Fine;
            tb_Osc3_Semi.Value = synthesizersData.osc3_Semi;

            tb_Formula.Text = synthesizersData.formula;

            rb_Formula.Checked = synthesizersData.isUsingFormula;
            rb_Oscillators.Checked = !synthesizersData.isUsingFormula;

            tb_Volume.Value = synthesizersData.volume;

            AMP_Attack.Value = synthesizersData.amp_attack;
            AMP_Decay.Value = synthesizersData.amp_decay;
            AMP_Sustain.Value = synthesizersData.amp_sustain;
            AMP_Release.Value = synthesizersData.amp_release;

            FilterType.SelectedIndex = synthesizersData.filter_index;
            cb_FilterBypass.Checked = synthesizersData.isBypass;
            Filter_Cutoff.Value = synthesizersData.filter_cutoff;
            Filter_Envelope_Octaves.Value = synthesizersData.filter_FEO;
            Filter_Attack.Value = synthesizersData.filter_attack;
            Filter_Decay.Value = synthesizersData.filter_decay;
            Filter_Sustain.Value = synthesizersData.filter_sustain;
            Filter_Release.Value = synthesizersData.filter_release;

            LFO_Waveform.SelectedIndex = synthesizersData.lfo_index;
            LFO_Frequency.Value = synthesizersData.lfo_frequency;
            LFO_Volume.Value = synthesizersData.lfo_amplitude;

            Reverb_Level.Value = synthesizersData.reverb_level;
            Reverb_Damp.Value = synthesizersData.reverb_damp;
            Reverb_Room.Value = synthesizersData.reverb_room;
        }
    }
}

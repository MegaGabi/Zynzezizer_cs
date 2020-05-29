using NAudio.Dsp;
using System;

namespace Zynzezizer_cs
{
    public class FilteredOscillator : Oscillator
    {
        private readonly EnvelopeGenerator _filterEnvelope;
        private readonly BiQuadFilter _filter;

        public FilteredOscillator(int sampleRate) : base(sampleRate, 2)
        {
            _filter = new BiQuadFilter(sampleRate);

            FilterCutoff = 1000;
            FilterEnvelopeOctaves = 0;

            _filterEnvelope = new EnvelopeGenerator();

            FilterAttack = .001f;
            FilterDecay = 2;
            FilterSustain = 0;
            FilterRelease = .001f;

            FilterLevel = 0;
        }

        double LogarithmicScale(double value)
        {
            var logValue = Math.Log10(value) * 1000;

            return logValue;
        }

        public float FilterCutoff { get; set; }

        public float FilterEnvelopeOctaves { get; set; }

        public float FilterQ
        {
            get { return _filter.Q; }
            set { _filter.Q = value; }
            }

        public FilterMode FilterMode
        {
            get { return _filter.Mode; }
            set { _filter.Mode = value; }
            }

        public float FilterAttack
        {
            get { return _filterEnvelope.AttackRate / WaveFormat.SampleRate; }
            set { _filterEnvelope.AttackRate = WaveFormat.SampleRate * value; }
            }

        public float FilterDecay
        {
            get { return _filterEnvelope.DecayRate / WaveFormat.SampleRate; }
            set { _filterEnvelope.DecayRate = WaveFormat.SampleRate * value; }
            }

        public float FilterSustain
        {
            get { return _filterEnvelope.SustainLevel; }
            set { _filterEnvelope.SustainLevel = value; }
            }

        public float FilterRelease
        {
            get { return _filterEnvelope.ReleaseRate / WaveFormat.SampleRate; }
            set { _filterEnvelope.ReleaseRate = WaveFormat.SampleRate * value; }
            }

        public float FilterLevel
        {
            get { return _filter.Wet; }
            set { _filter.Wet = value; }
            }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            var samplesRead = base.Read(buffer, offset, sampleCount);

            if (Math.Abs(_filter.Wet) < float.Epsilon)
                return samplesRead;

            for (var i = 0; i < samplesRead; ++i)
            {
                _filter.Cutoff = (float)(FilterCutoff * Math.Pow(2, FilterEnvelopeOctaves * _filterEnvelope.Process()));
                buffer[offset + i] = _filter.Apply(buffer[offset + i]) * _filter.Wet + buffer[offset + i] * (1 - _filter.Wet);
            }

            return samplesRead;
        }

        public new void NoteOn()
        {
            base.NoteOn();
            _filterEnvelope.Gate(true);
        }

        public new void NoteOff()
        {
            base.NoteOff();
            _filterEnvelope.Gate(false);
        }
    }
}
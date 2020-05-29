using System;
using NAudio.Wave;
using NAudio.Dsp;

namespace Zynzezizer_cs
{
    public class Oscillator : WaveProvider32
    {
        private EnvelopeGenerator _amplitudeEnvelope;
        private bool _isPlaying;
        private double _phase;
        private double _lfoPhase;
        private float _tuning;
        private int _note;
        private LFO _lfo;

        public EventHandler FinishedPlaying;

        public Oscillator(int sampleRate, int channels) : base(sampleRate, channels)
        {
            _amplitudeEnvelope = new EnvelopeGenerator();
            _lfo = new LFO();
            _isPlaying = false;

            Attack = .001f;
            Decay = 0;
            Sustain = 1;
            Release = .001f;

            Amplitude = 1;

            _tuning = 440;
            _note = 49;
            Frequency = 440;

            LFOAmplitude = 0;
            LFOFrequency = 1;

            Function = x => (float)Math.Sin(2 * Math.PI * x);
            LFOFunction = x => (float)Math.Sin(2 * Math.PI * x);

            _phase = 0;
            _lfoPhase = 0;
        }

        public Func<float, float> Function { get; set; }

        public Func<float, float> LFOFunction { get { return _lfo.Function; }
                                                set { _lfo.Function = value; } }

        public float LFOAmplitude { get { return _lfo.Amplitude; }
                                    set { _lfo.Amplitude = value; } }

        public float LFOFrequency { get { return _lfo.frequency; }
                                  set { _lfo.frequency = value; } }

        public float Attack
        {
            get { return _amplitudeEnvelope.AttackRate / WaveFormat.SampleRate; }
            set { _amplitudeEnvelope.AttackRate = WaveFormat.SampleRate * value; }
        }

        public float Decay
        {
            get { return _amplitudeEnvelope.DecayRate / WaveFormat.SampleRate; }
            set { _amplitudeEnvelope.DecayRate = WaveFormat.SampleRate * value; }
            }

        public float Sustain
        {
            get { return _amplitudeEnvelope.SustainLevel; }
            set { _amplitudeEnvelope.SustainLevel = value; }
            }

        public float Release
        {
            get { return _amplitudeEnvelope.ReleaseRate / WaveFormat.SampleRate; }
            set { _amplitudeEnvelope.ReleaseRate = WaveFormat.SampleRate * value; }
            }

        public float Amplitude { get; set; }


        private static float NoteToFreq(int note, float tuning)
        {
            return (float)(tuning * Math.Pow(2, (note - 49) / 12.0f));
        }
        public float Frequency { get; set; }

        public float Tuning
        {
            get { return _tuning; }
            set
            {
                _tuning = value;
                Frequency = NoteToFreq(_note, _tuning);
            }
            }

        // can be outdated
        public int Note
        {
            get { return _note; }
            set
            {
                _note = value;
                Frequency = NoteToFreq(_note, _tuning);
            }
            }

        public bool IsPlaying()
        {
            return _isPlaying;
        }

        public bool IsOnRelease()
        {
            return _amplitudeEnvelope.State == EnvelopeGenerator.EnvelopeState.Release;
        }

        public void NoteOn()
        {
            _amplitudeEnvelope.Gate(true);
            _isPlaying = true;
        }

        public void NoteOff()
        {
            _amplitudeEnvelope.Gate(false);
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (var index = 0; index < sampleCount; index += WaveFormat.Channels)
            {
                if (_amplitudeEnvelope.State != EnvelopeGenerator.EnvelopeState.Idle)
                {
                    _phase = _phase + Frequency / WaveFormat.SampleRate;
                    _lfoPhase = _lfoPhase + LFOFrequency / WaveFormat.SampleRate;

                    float lfoCoef = Amplitude - (_lfo.Function((float)_lfoPhase) * _lfo.Amplitude);
                    buffer[offset + index] = lfoCoef * Function((float)_phase) * _amplitudeEnvelope.Process();

                    for (var channel = 1; channel < WaveFormat.Channels; ++channel)
                        buffer[offset + index + channel] = buffer[offset + index];
                }
                else
                {
                    if (_isPlaying)
                    {
                        _isPlaying = false;
                        FinishedPlaying?.Invoke(this, new EventArgs());
                        _phase = 0;
                        _lfoPhase = 0;
                    }

                    for (var channel = 0; channel < WaveFormat.Channels; ++channel)
                        buffer[index + offset + channel] = 0;
                }
            }

            return sampleCount;
        }
    }
}
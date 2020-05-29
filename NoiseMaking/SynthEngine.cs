using System;
using NAudio.Wave;
using System.Collections.Generic;

namespace Zynzezizer_cs
{
    public class SynthEngine : WaveProvider32
    {
        public enum Waveforms { Sine, Sawtooth, Square, Triangle, Noise, Custom };

        private Waveforms _waveform;
        private WaveMixer32 _mixer;
        private List<FilteredOscillator> _oscillators;
        private Freeverb _reverb;
        private LookaheadLimiter _limiter;

        private Random _random;

        public SynthEngine(int sampleRate, int voiceCount)
            : base(sampleRate, 2)
        {
            _mixer = new WaveMixer32(sampleRate, 2);

            _oscillators = new List<FilteredOscillator>(voiceCount);
            for (var i = 0; i < voiceCount; ++i)
                _oscillators.Add(new FilteredOscillator(sampleRate));

            _reverb = new Freeverb(_mixer, .84f, .2f) { Wet = 0 };

            _limiter = new LookaheadLimiter(_reverb, 1, 64);

            _random = new Random();

            FilterLevel = 0;
            FilterEnvelopeOctaves = 0;
        }

        public Func<float, float> WaveformFunction
        {
            get { return _oscillators[0].Function; }
            set { _oscillators.ForEach(osc => osc.Function = value); }
        }

        public float Amplitude
        {
            get { return _oscillators[0].Amplitude; }
            set { _oscillators.ForEach(osc => osc.Amplitude = value); }
        }

        public Func<float, float> LFOFunction
        {
            get { return _oscillators[0].LFOFunction; }
            set { _oscillators.ForEach(osc => osc.LFOFunction = value); }
        }

        public float LFOAmplitude
        {
            get { return _oscillators[0].LFOAmplitude; }
            set { _oscillators.ForEach(osc => osc.LFOAmplitude = value); }
        }
        public float LFOFrequency
        {
            get { return _oscillators[0].LFOFrequency; }
            set { _oscillators.ForEach(osc => osc.LFOFrequency = value); }
        }

        public float Attack
        {
            get { return _oscillators[0].Attack; }
            set { _oscillators.ForEach(osc => osc.Attack = value); }
        }

        public float Decay
        {
            get { return _oscillators[0].Decay; }
            set { _oscillators.ForEach(osc => osc.Decay = value); }
        }

        public float Sustain
        {
            get { return _oscillators[0].Sustain; }
            set { _oscillators.ForEach(osc => osc.Sustain = value); }
        }

        public float Release
        {
            get { return _oscillators[0].Release; }
            set { _oscillators.ForEach(osc => osc.Release = value); }
        }

        public float FilterCutoff
        {
            get { return _oscillators[0].FilterCutoff; }
            set { _oscillators.ForEach(osc => osc.FilterCutoff = value); }
        }

        public float FilterQ
        {
            get { return _oscillators[0].FilterQ; }
            set { _oscillators.ForEach(osc => osc.FilterQ = value); }
        }

        public FilterMode FilterMode
        {
            get { return _oscillators[0].FilterMode; }
            set { _oscillators.ForEach(osc => osc.FilterMode = value); }
        }

        public float FilterLevel
        {
            get { return _oscillators[0].FilterLevel; }
            set { _oscillators.ForEach(osc => osc.FilterLevel = value); }
        }

        public float FilterAttack
        {
            get { return _oscillators[0].FilterAttack; }
            set { _oscillators.ForEach(osc => osc.FilterAttack = value); }
        }

        public float FilterSustain
        {
            get { return _oscillators[0].FilterSustain; }
            set { _oscillators.ForEach(osc => osc.FilterSustain = value); }
        }

        public float FilterDecay
        {
            get { return _oscillators[0].FilterDecay; }
            set { _oscillators.ForEach(osc => osc.FilterDecay = value); }
        }

        public float FilterRelease
        {
            get { return _oscillators[0].FilterRelease; }
            set { _oscillators.ForEach(osc => osc.FilterRelease = value); }
        }

        public float FilterEnvelopeOctaves
        {
            get { return _oscillators[0].FilterEnvelopeOctaves; }
            set { _oscillators.ForEach(osc => osc.FilterEnvelopeOctaves = value); }
        }

        public void NoteOn(int note)
        {
            var osc = _oscillators.Find(x => !x.IsPlaying());

            if (osc != default(FilteredOscillator))
            {
                osc.Note = note;
                osc.NoteOn();
                _mixer.AddInput(osc);
            }
            else
                Console.WriteLine("exceded max number of voices ({0})", _oscillators.Count);
        }

        public void NoteOff(int note)
        {
            var osc = _oscillators.Find(x => x.IsPlaying() && x.Note == note && !x.IsOnRelease());

            if (osc == default(FilteredOscillator)) return;

            osc.FinishedPlaying = (s, e) =>
            {
                _mixer.RemoveInput(osc);
                osc.FinishedPlaying = null;
            };
            osc.NoteOff();
        }

        public float ReverbLevel
        {
            get { return _reverb.Wet; }
            set { _reverb.Wet = value; }
        }

        public float ReverbRoomSize
        {
            get { return _reverb.RoomSize; }
            set { _reverb.RoomSize = value; }
        }

        public float ReverbDamping
        {
            get { return _reverb.Damping; }
            set { _reverb.Damping = value; }
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            return _limiter.Read(buffer, offset, count);
        }
    }
}
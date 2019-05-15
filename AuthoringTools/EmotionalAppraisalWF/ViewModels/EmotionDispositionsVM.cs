using System.Collections.Generic;
using System.Linq;
using EmotionalAppraisal;
using EmotionalAppraisal.DTOs;
using Equin.ApplicationFramework;

namespace EmotionalAppraisalWF.ViewModels
{
    public class EmotionDispositionsVM
    {
	    private BaseEAForm _mainForm;
	    private EmotionalAppraisalAsset _emotionalAppraisalAsset => _mainForm.LoadedAsset;

        public BindingListView<EmotionDispositionDTO> EmotionDispositions {get;}
	    private EmotionDispositionDTO _defaultEmotionalDisposition;

		public int DefaultThreshold
        {
            get { return _defaultEmotionalDisposition.Threshold; }
	        set
	        {
		        _defaultEmotionalDisposition.Threshold = value;
				UpdateDefaultEmotionDisposition();
	        }
        }

        public int DefaultDecay
        {
            get { return _defaultEmotionalDisposition.Decay; }
	        set
	        {
		        _defaultEmotionalDisposition.Decay = value;
				UpdateDefaultEmotionDisposition();
	        }
        }

        public EmotionDispositionsVM(BaseEAForm form)
        {
	        _mainForm = form;
            this.EmotionDispositions = new BindingListView<EmotionDispositionDTO>(_emotionalAppraisalAsset.EmotionDispositions.ToList());
	        _defaultEmotionalDisposition = _emotionalAppraisalAsset.DefaultEmotionDisposition;
        }
		
        public void AddEmotionDisposition(EmotionDispositionDTO disp)
        {
            _emotionalAppraisalAsset.AddEmotionDisposition(disp);
            EmotionDispositions.DataSource = _emotionalAppraisalAsset.EmotionDispositions.ToList();
            EmotionDispositions.Refresh();
			_mainForm.SetModified();
		}

        public void UpdateEmotionDisposition(EmotionDispositionDTO oldDisp, EmotionDispositionDTO newDisp)
        {
            _emotionalAppraisalAsset.RemoveEmotionDisposition(oldDisp.Emotion);
            _emotionalAppraisalAsset.AddEmotionDisposition(newDisp);
            EmotionDispositions.DataSource = _emotionalAppraisalAsset.EmotionDispositions.ToList();
            EmotionDispositions.Refresh();
			_mainForm.SetModified();
		}

        private void UpdateDefaultEmotionDisposition()
        {
	        _emotionalAppraisalAsset.DefaultEmotionDisposition = _defaultEmotionalDisposition;
			_mainForm.SetModified();
        }

        public void RemoveDispositions(IList<EmotionDispositionDTO> dispositionsToRemove)
        {
            foreach (var emotionDispositionDto in dispositionsToRemove)
            {
                _emotionalAppraisalAsset.RemoveEmotionDisposition(emotionDispositionDto.Emotion);
            }
            EmotionDispositions.DataSource = _emotionalAppraisalAsset.EmotionDispositions.ToList();
            EmotionDispositions.Refresh();
			_mainForm.SetModified();
		}

        public void SavePersonalityFactors(double o, double c, double e, double a, double n) {
            _emotionalAppraisalAsset.setPersonalityFactor("Openness", o);
            _emotionalAppraisalAsset.setPersonalityFactor("Conscientiousness", c);
            _emotionalAppraisalAsset.setPersonalityFactor("Extraversion", e);
            _emotionalAppraisalAsset.setPersonalityFactor("Agreeableness", a);
            _emotionalAppraisalAsset.setPersonalityFactor("Neuroticism", n);
            _mainForm.SetModified();
        }

        public void resetDispositionOnPersonality() {
            List<EmotionDispositionDTO> dispositions = _emotionalAppraisalAsset.getPersonalityDispositions();
            IList<EmotionDispositionDTO> current = _emotionalAppraisalAsset.EmotionDispositions.ToList();
            RemoveDispositions(current);
            foreach (var i in dispositions) {
                AddEmotionDisposition(i);
            }
            _mainForm.SetModified();
        }

        public double[] getFactors() {
            double[] ret = new double[5] {
                _emotionalAppraisalAsset.getPersonalityFactor("Openness"),
                _emotionalAppraisalAsset.getPersonalityFactor("Conscientiousness"),
                _emotionalAppraisalAsset.getPersonalityFactor("Extraversion"),
                _emotionalAppraisalAsset.getPersonalityFactor("Agreeableness"),
                _emotionalAppraisalAsset.getPersonalityFactor("Neuroticism") };
            return ret;
        }
    }
}

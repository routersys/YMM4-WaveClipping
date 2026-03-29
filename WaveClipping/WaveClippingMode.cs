using System.ComponentModel.DataAnnotations;

namespace WaveClipping
{
    public enum WaveClippingMode
    {
        [Display(Name = nameof(Texts.ModeUnidirectional), Description = nameof(Texts.ModeUnidirectionalDescription), ResourceType = typeof(Texts))]
        Unidirectional,

        [Display(Name = nameof(Texts.ModeBidirectional), Description = nameof(Texts.ModeBidirectionalDescription), ResourceType = typeof(Texts))]
        Bidirectional,

        [Display(Name = nameof(Texts.ModeBidirectionalInverted), Description = nameof(Texts.ModeBidirectionalInvertedDescription), ResourceType = typeof(Texts))]
        BidirectionalInverted,
    }
}
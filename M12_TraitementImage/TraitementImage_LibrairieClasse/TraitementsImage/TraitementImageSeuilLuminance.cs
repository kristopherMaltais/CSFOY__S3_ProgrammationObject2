﻿using System;
using System.Collections.Generic;
using static TraitementImage_LibrairieClasse.UtilitaireTraitements;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TraitementImage_LibrairieClasse.TraitementsImage
{
    [Description("Traiter le seuil luminance de l'image")]
    class TraitementImageSeuilLuminance : ITraitementImage
    {
        // ** Champs ** //

        // ** Propriétés ** //
        [Browsable(false)]
        public ITraitementImage Suivant { get; set; }
        public int Seuil { get; set; }

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public void TraiterImage(ImageManipulable p_image)
        {
            byte[] raw = p_image.Raw;
            for (int longueur = 0; longueur < raw.Length / 3; longueur++)
            {
                int l3 = longueur * 3;
                byte luminance = (byte)((raw[l3] + raw[l3 + 1] + raw[l3 + 2]) / 3);
                byte valeur = 0;
                if (luminance > this.Seuil)
                {
                    valeur = 255;
                }
                raw[l3] = valeur;
                raw[l3 + 1] = valeur;
                raw[l3 + 2] = valeur;
            }

            this.Suivant?.TraiterImage(p_image);
        }
        public override string ToString()
        {
            return UtilitaireTraitements.DescriptionTraitement(this);
        }
    }
}

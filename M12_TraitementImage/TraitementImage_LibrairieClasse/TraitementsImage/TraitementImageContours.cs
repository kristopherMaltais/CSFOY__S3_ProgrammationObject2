﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitementImage_LibrairieClasse.TraitementsImage
{
    [Description("Traiter le contour de l'image")]
    public class TraitementImageContours : TraitementImageMasque
    {
        // ** Champs ** //

        // ** Propriétés ** //

        // ** Constructeur ** //
        public TraitementImageContours()
        {
            base.Transformation = t =>
            {
                return TraiterDonnees(t);
            };
        }

        // ** Méthodes ** //
        private static byte TraiterDonnees(byte[] p_donnees)
        {
            int coeficientCentrale = p_donnees.Length - 1;
            int posCentrale = p_donnees.Length / 2;
            int somme = 0;
            for (int i = 0; i < posCentrale; i++)
            {
                somme -= p_donnees[i];
            }
            somme += coeficientCentrale * p_donnees[posCentrale];
            for (int i = posCentrale + 1; i < p_donnees.Length; i++)
            {
                somme -= p_donnees[i];
            }
            return (byte)(somme / p_donnees.Length);
        }
        public override string ToString()
        {
            return UtilitaireTraitements.DescriptionTraitement(this);
        }
    }
}

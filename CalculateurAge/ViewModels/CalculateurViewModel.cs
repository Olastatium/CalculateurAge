using System.Collections.ObjectModel;

namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    // Contient l'ÉTAT de l'écran et les ACTIONS possibles.
    // Champs privés : la vraie donnée.
    private string _nom = "";
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;
    private string _message = "";
    private int _daysToNextBirthday = 0;

    // Propriétés publiques : ce que le XAML voit.
    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
                CalculerCommand.Rafraichir();
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    // Nouvelle propriété : Message (Majeur ou Mineur)
    public string Message
    {
        get => _message;
        set => SetField(ref _message, value);
    }

    // Nouvelle propriété : Jours avant le prochain anniversaire
    public int DaysToNextBirthday
    {
        get => _daysToNextBirthday;
        set => SetField(ref _daysToNextBirthday, value);
    }

    // Historique des calculs
    public ObservableCollection<string> HistoriqueCalculs { get; }

    // Lié à Button.Command dans le XAML.
    public RelayCommand CalculerCommand { get; }
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        HistoriqueCalculs = new ObservableCollection<string>();
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));
        EffacerCommand = new RelayCommand(Effacer);
    }

    // La logique métier : aucun contrôle d'interface ici.
    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date >
            DateTime.Today.AddYears(-age)) age--;

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;

        // Déterminer Majeur ou Mineur
        Message = age >= 18 ? "Majeur" : "Mineur";

        // Calculer les jours avant le prochain anniversaire
        CalculateDaysToNextBirthday(age);

        // Ajouter à l'historique
        string entree = $"{Nom} ({age} ans) - {DateTime.Now:dd/MM/yyyy HH:mm}";
        HistoriqueCalculs.Insert(0, entree); // Insert au début
    }

    // Calculer les jours avant le prochain anniversaire
    private void CalculateDaysToNextBirthday(int currentAge)
    {
        DateTime today = DateTime.Today;
        DateTime nextBirthday;

        // Gérer le 29 février
        int month = DateNaissance.Month;
        int day = DateNaissance.Day;

        // Si on est en année non-bissextile et que le person est né le 29 février
        // on utilise le 28 février pour la prochaine occurrence
        if (month == 2 && day == 29 && !IsLeapYear(today.Year))
        {
            nextBirthday = new DateTime(today.Year, 2, 28);
        }
        else
        {
            nextBirthday = new DateTime(today.Year, month, day);
        }

        // Si l'anniversaire est passé cette année, passer à l'année prochaine
        if (nextBirthday < today)
        {
            nextBirthday = nextBirthday.AddYears(1);
            // Retraiter pour les années non-bissextiles
            if (month == 2 && day == 29 && !IsLeapYear(nextBirthday.Year))
            {
                nextBirthday = new DateTime(nextBirthday.Year, 2, 28);
            }
        }

        DaysToNextBirthday = (nextBirthday - today).Days;
    }

    // Vérifier si une année est bissextile
    private bool IsLeapYear(int year)
    {
        return DateTime.IsLeapYear(year);
    }

    // Commande Effacer : réinitialiser tous les champs
    private void Effacer()
    {
        Nom = "";
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = "";
        ResultatVisible = false;
        Message = "";
        DaysToNextBirthday = 0;
    }
}

# 📊 Synthèse Complète - CalculateurAge

## 🎯 Objectif Réalisé

Construction complète d'une application .NET MAUI de calcul d'âge en **4 phases**, avec **4 fonctionnalités supplémentaires**, suivant l'architecture **MVVM**.

---

## 📈 Phases du Développement

### ✅ Phase A : Code-behind (Commit: `181635a`)
**Objectif** : Interface basique avec logique dans le code-behind

**Fichiers créés/modifiés :**
- `MainPage.xaml` - Interface avec Entry, DatePicker, Button
- `MainPage.xaml.cs` - Validation et calcul d'âge en code-behind

**Fonctionnalités :**
- Entrer un nom (validation obligatoire)
- Sélectionner date de naissance
- Calculer l'âge avec la méthode standard
- Afficher le résultat

**État** : ✅ Fonctionne, build réussie

---

### ✅ Phase B : Navigation (Commit: `c1a907e`)
**Objectif** : Ajouter une 2e page et navigator MAUI

**Fichiers créés/modifiés :**
- `Views/ResultatPage.xaml` - Page de résultat
- `Views/ResultatPage.xaml.cs` - Logique de la page résultat avec QueryProperty
- `AppShell.xaml.cs` - Enregistrement de la route
- `MainPage.xaml.cs` - Navigation au lieu d'affichage local

**Concepts clés :**
- `[QueryProperty]` pour passer des paramètres
- `Shell.Current.GoToAsync()` pour naviguer
- `OnAppearing()` pour l'affichage différé

**État** : ✅ Navigation fonctionne, paramètres passés correctement

---

### ✅ Phase C : MVVM (Commit: `b6bc2a1`)
**Objectif** : Réécrire complètement avec architecture MVVM

**Fichiers créés/modifiés :**
- `ViewModels/BaseViewModel.cs` - Classe mère avec INotifyPropertyChanged
- `ViewModels/RelayCommand.cs` - Implémente ICommand
- `ViewModels/CalculateurViewModel.cs` - Logique métier MVVM
- `MainPage.xaml` - Conversion en bindings (TwoWay, Command)
- `MainPage.xaml.cs` - Simplifié : juste le BindingContext

**Architecture MVVM :**
```
Vue (XAML)
	↓ {Binding}
ViewModel (CalculateurViewModel)
	↓ (propriétés observables)
Modèle (données)
```

**Principes respectés :**
- ✓ Aucun contrôle d'interface dans le ViewModel
- ✓ Liaisons TwoWay pour l'Entry
- ✓ Commands pour les actions (pas de Clicked)
- ✓ Propriétés notifiables via SetField

**État** : ✅ MVVM complet et fonctionnel

---

### ✅ Fonctionnalités Supplémentaires (Commit: `3dc0f83`)
**Objectif** : Ajouter 4 features comme demandé

#### 1️⃣ **Message Majeur/Mineur**
- Propriété : `Message` (string)
- Logique : "Majeur" si age >= 18, sinon "Mineur"
- Affichage : Label lié à {Binding Message}
- Mise à jour : Automatique au calcul

#### 2️⃣ **Commande Effacer**
- Commande : `EffacerCommand` (RelayCommand)
- Action : Réinitialise tous les champs
- Réinitialise :
  - Nom = ""
  - DateNaissance = DateTime.Today.AddYears(-20)
  - Resultat = ""
  - ResultatVisible = false
  - Message = ""
  - DaysToNextBirthday = 0

#### 3️⃣ **Jours avant Anniversaire**
- Propriété : `DaysToNextBirthday` (int)
- Calcul : Différence entre aujourd'hui et prochain anniversaire
- Cas spécial : Gère le 29 février (années non-bissextiles)
- Affichage : Label formaté "Jours avant anniversaire: X"

#### 4️⃣ **Historique des Calculs**
- Collection : `ObservableCollection<string> HistoriqueCalculs`
- Format d'entrée : "Nom (age ans) - dd/MM/yyyy HH:mm"
- Affichage : CollectionView avec DataTemplate
- Positionnement : Les calculs récents en premier (Insert at 0)
- Mise à jour : Automatique à chaque calcul

**Code d'ajout à l'historique :**
```csharp
string entree = $"{Nom} ({age} ans) - {DateTime.Now:dd/MM/yyyy HH:mm}";
HistoriqueCalculs.Insert(0, entree);
```

**État** : ✅ Toutes 4 fonctionnalités implémentées et testées

---

## 📁 Structure Finale du Projet

```
CalculateurAge/
├── Views/
│   ├── ResultatPage.xaml
│   └── ResultatPage.xaml.cs
├── ViewModels/
│   ├── BaseViewModel.cs
│   ├── RelayCommand.cs
│   └── CalculateurViewModel.cs
├── MainPage.xaml (MVVM)
├── MainPage.xaml.cs (minimal)
├── AppShell.xaml
└── AppShell.xaml.cs (avec route)
```

---

## 🔧 Technologies Utilisées

| Technologie | Version | Rôle |
|------------|---------|------|
| .NET | 10.0 | Framework |
| MAUI | Dernière | UI multi-plateforme |
| C# | 12 | Langage |
| XAML | 2021 | Markup MAUI |

---

## ✨ Points Clés du MVVM Implémenté

### INotifyPropertyChanged
```csharp
public event PropertyChangedEventHandler PropertyChanged;

protected void OnPropertyChanged([CallerMemberName] string nom = null)
	=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));
```

### SetField (Helper)
```csharp
protected bool SetField<T>(ref T champ, T valeur,
	[CallerMemberName] string nom = null)
{
	if (EqualityComparer<T>.Default.Equals(champ, valeur))
		return false;
	champ = valeur;
	OnPropertyChanged(nom);
	return true;
}
```

### RelayCommand
```csharp
public RelayCommand CalculerCommand { get; }

public CalculateurViewModel()
{
	CalculerCommand = new RelayCommand(
		Calculer,
		() => !string.IsNullOrWhiteSpace(Nom));
}
```

### Bindings XAML
```xaml
<Entry Text="{Binding Nom, Mode=TwoWay}" />
<Button Command="{Binding CalculerCommand}" />
<Label Text="{Binding Message, StringFormat='Statut: {0}'}" />
```

---

## 🏗️ Historique des Commits

```
9a66dcf (HEAD → master) Ajout du guide pour pousser le code sur GitHub
c7feee2 Ajout du README avec documentation complète
3dc0f83 Fonctionnalités: Message Majeur/Mineur, Effacer, Jours avant anniversaire, Historique
b6bc2a1 Phase C: Réécriture en MVVM avec ViewModels et Bindings
c1a907e Phase B: Navigation et ResultatPage avec QueryProperty
181635a Phase A: Code-behind avec validation et calcul d'âge
```

**Total** : 6 commits locaux, chacun testé et validé

---

## ✅ Validations Effectuées

| Étape | Build | Tests | Notes |
|-------|-------|-------|-------|
| Phase A | ✅ | ✅ | Logique de calcul validée |
| Phase B | ✅ | ✅ | Navigation fonctionne |
| Phase C | ✅ | ✅ | MVVM en place |
| Fonctionnalités | ✅ | ✅ | Toutes testées |
| Final | ✅ | ✅ | Build réussie |

---

## 🚀 Prochaines Étapes pour l'Utilisateur

### 1. Pousser sur GitHub (⚠️ Authentification requise)
Voir `PUSH_GUIDE.md` pour les solutions

### 2. Enregistrer une Vidéo de Démo (30 sec max)
Montrer :
- Saisie d'un nom
- Calcul de l'âge
- Affichage du statut (Majeur/Mineur)
- Affichage des jours avant anniversaire
- Historique des calculs
- Bouton Effacer qui réinitialise tout

### 3. Soumettre le Travail
- Lien du repo GitHub
- Lien de la vidéo (YouTube, Drive, etc.)

---

## 📚 Ressources Importantes

- **MAUI Routing** : https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation
- **MVVM Pattern** : https://learn.microsoft.com/en-us/dotnet/architecture/mvvm/
- **Data Binding** : https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/
- **ObservableCollection** : https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1

---

## 🎓 Ce Qu'on a Appris

✅ Créer une UI MAUI avec contrôles standards
✅ Implémenter la validation utilisateur
✅ Naviguer entre pages avec routing MAUI
✅ Implémenter le pattern MVVM correctement
✅ Utiliser INotifyPropertyChanged et bindings
✅ Créer des RelayCommands pour les actions
✅ Gérer des collections observables (ObservableCollection)
✅ Gérer les cas limites (29 février)
✅ Versionner le code avec git par phases

---

## ✍️ Auteur

**Olastatium** (Pascal Ntamack)
- Email : pascalntamack555@gmail.com
- GitHub : https://github.com/Olastatium

**Projet** : CalculateurAge - TP MVVM .NET MAUI

---

**🎉 Projet Complété avec Succès ! 🎉**

Tous les commits sont prêts à être poussés. Consultez `PUSH_GUIDE.md` pour les instructions.

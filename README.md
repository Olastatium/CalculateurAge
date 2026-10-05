# CalculateurAge

Une application .NET MAUI pour calculer l'âge d'une personne et afficher des informations liées.

## 📋 Phases du Projet

### Phase A - Code-behind
Application basique avec interface et logique métier dans le code-behind.
- Interface de saisie (Nom, Date de naissance)
- Bouton Calculer qui affiche le résultat

### Phase B - Navigation
Ajout d'une deuxième page et du routage MAUI.
- Page ResultatPage pour afficher les résultats
- Navigation avec paramètres QueryProperty
- Bouton Retour pour revenir à la page principale

### Phase C - MVVM
Réécriture complète en architecture MVVM.
- BaseViewModel avec INotifyPropertyChanged
- RelayCommand pour les actions utilisateur
- Bindings TwoWay et OneWay
- Séparation complète entre UI et logique métier

## 🎯 Fonctionnalités Ajoutées

1. **Message Majeur/Mineur**
   - Affiche "Majeur" si l'âge >= 18, sinon "Mineur"
   - Mise à jour automatique lors du calcul

2. **Commande Effacer**
   - Bouton "Effacer" pour réinitialiser tous les champs
   - Remet le formulaire à son état initial

3. **Jours avant Anniversaire**
   - Calcule le nombre de jours restants jusqu'au prochain anniversaire
   - Gère correctement le 29 février (années non-bissextiles)

4. **Historique des Calculs**
   - ObservableCollection affichée dans un CollectionView
   - Chaque entrée contient: Nom, Âge, Date/Heure
   - Les calculs les plus récents apparaissent en premier

## 📁 Structure du Projet

```
CalculateurAge/
├── Views/
│   ├── ResultatPage.xaml
│   └── ResultatPage.xaml.cs
├── ViewModels/
│   ├── BaseViewModel.cs
│   ├── RelayCommand.cs
│   └── CalculateurViewModel.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── AppShell.xaml
└── AppShell.xaml.cs
```

## 🚀 Utilisation

1. Entrez votre nom
2. Sélectionnez votre date de naissance
3. Cliquez sur "Calculer" pour voir:
   - Votre âge exact
   - Votre statut (Majeur/Mineur)
   - Jours avant votre prochain anniversaire
4. Consultez l'historique de tous les calculs effectués
5. Cliquez sur "Effacer" pour réinitialiser

## 💻 Technologie

- **.NET 10**
- **.NET MAUI** (Multi-platform App UI)
- **MVVM** (Model-View-ViewModel)
- **C# 12**

## 📝 Commits Git

- `181635a` - Phase A: Code-behind avec validation et calcul d'âge
- `c1a907e` - Phase B: Navigation et ResultatPage avec QueryProperty
- `b6bc2a1` - Phase C: Réécriture en MVVM avec ViewModels et Bindings
- `3dc0f83` - Fonctionnalités: Message Majeur/Mineur, Effacer, Jours avant anniversaire, Historique

## 📌 Points Clés MVVM

- **ViewModel** ne contient aucun contrôle d'interface (No Label, Entry, Button, DisplayAlert)
- **BaseViewModel** implémente INotifyPropertyChanged pour les bindings
- **RelayCommand** transforme les méthodes en commandes liables aux boutons
- **Bindings TwoWay** permettent la mise à jour bidirectionnelle des données
- **HistoriqueCalculs** est une ObservableCollection qui se met à jour automatiquement

## ✅ Respect du MVVM

✓ Logique métier isolée dans le ViewModel
✓ Vue sans logique métier (XAML uniquement)
✓ Code-behind minimal (juste l'initialisation du BindingContext)
✓ Notification des changements via INotifyPropertyChanged
✓ Actions utilisateur via Commands (pas d'événements Clicked)

## 📬 Auteur

Olastatium (Pascal Ntamack)
Email: pascalntamack555@gmail.com

# 📤 Guide pour Pousser le Code sur GitHub

## Problème Actuel
Le push sur GitHub échoue en raison de l'authentification. Vous avez **5 commits locaux** prêts à être poussés :

```
c7feee2 (HEAD → master) Ajout du README avec documentation complète
3dc0f83 Fonctionnalités: Message Majeur/Mineur, Effacer, Jours avant anniversaire, Historique
b6bc2a1 Phase C: Réécriture en MVVM avec ViewModels et Bindings
c1a907e Phase B: Navigation et ResultatPage avec QueryProperty
181635a Phase A: Code-behind avec validation et calcul d'âge
```

## Solutions pour Pousser

### Option 1 : Utiliser un Personal Access Token (PAT) - RECOMMANDÉ ⭐

1. **Générer un PAT sur GitHub :**
   - Aller sur https://github.com/settings/tokens/new
   - Créer un nouveau token avec la portée `repo`
   - Copier le token généré

2. **Configurer git avec le PAT :**
   ```powershell
   cd C:\Users\KAMSTORE\source\repos\CalculateurAge\
   git config --global credential.helper store
   ```

3. **Pousser vers GitHub :**
   ```powershell
   git push -u origin master
   ```
   - Lorsque demandé, entrer :
	 - **Username** : `Olastatium`
	 - **Password** : Coller votre PAT

4. **Les credentials seront sauvegardés pour les futures opérations**

### Option 2 : Utiliser SSH

1. **Générer une clé SSH :**
   ```powershell
   ssh-keygen -t ed25519 -C "pascalntamack555@gmail.com"
   ```
   - Appuyer sur Entrée pour les prompts (utiliser les défauts)

2. **Ajouter la clé publique à GitHub :**
   - Aller sur https://github.com/settings/keys
   - Cliquer "New SSH key"
   - Copier le contenu de `~/.ssh/id_ed25519.pub`

3. **Changer l'URL du remote :**
   ```powershell
   git remote set-url origin git@github.com:Olastatium/CalculateurAge.git
   ```

4. **Pousser les commits :**
   ```powershell
   git push -u origin master
   ```

### Option 3 : Recréer le repo avec les bons credentials

Si aucune option ci-dessus ne fonctionne :

1. **Créer un nouveau dossier de travail :**
   ```powershell
   cd C:\temp
   git clone https://Olastatium:YOUR_PAT@github.com/Olastatium/CalculateurAge.git CalculateurAge_nouveau
   cd CalculateurAge_nouveau
   ```

2. **Copier vos fichiers de source :**
   - Copier tous les fichiers du dossier `CalculateurAge/` (sauf `.git`)

3. **Commiter et pousser :**
   ```powershell
   git add -A
   git commit -m "Migration de CalculateurAge"
   git push origin master
   ```

## 📝 Commits Prêts à Pousser

| Commit | Message | Description |
|--------|---------|-------------|
| `181635a` | Phase A | Validation et calcul d'âge en code-behind |
| `c1a907e` | Phase B | Navigation avec ResultatPage |
| `b6bc2a1` | Phase C | Réécriture MVVM complète |
| `3dc0f83` | Fonctionnalités | 4 nouvelles fonctionnalités |
| `c7feee2` | Documentation | README avec explications |

## ⚠️ Dépannage

**Erreur : "fatal: unable to access ... 403"**
- → Le PAT est incorrect ou expiré
- → Vérifiez les credentials sauvegardés : `git credential-manager erase https://github.com`
- → Réessayez avec un nouveau PAT

**Erreur : "Permission denied (publickey)"**
- → La clé SSH n'est pas configurée correctement
- → Vérifiez : `ssh -T git@github.com`

**Erreur : "error: src refspec master does not match any"**
- → Le repo local n'a pas de branche `master`
- → Solution : `git push -u origin HEAD:main`

## ✅ Après le Push

Une fois poussé avec succès, vous pouvez vérifier sur GitHub :
```
https://github.com/Olastatium/CalculateurAge
```

Le repos contiendra l'historique complet des 5 commits avec toutes les phases et fonctionnalités.

---

**Besoin d'aide ?** Consultez la documentation officielle : https://docs.github.com/en/authentication

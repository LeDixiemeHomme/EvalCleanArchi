#TODO un paragraphe sur les commentaires du code existant et de sa structure, les pb vus etc
- beaucoup de code dans des if, pas une bonne chose 
- aucune fonction donc aucun test, pas une bonne chose
- pas de try catch dans le cas ou le fichier n'existe pas, pas une bonne chose

#TODO un paragraphe sur comment il faudrait structurer le code et les entités utilisées
Peut etre utiliser un pattern qui permet de simplifier la structure du if else, on pourrait utiliser un strategy pattern.
Extraire du code dans des fonctions pour tester le code.
Il faudrait une entité ou class par commande possible, comme "print" ou "report".

#TODO un paragraphe avec la stratégie de tests: qu'est ce que je veux tester, quels exemples, pourquoi etc..
- ajout d'un second test de golden master avec un set de données supplémentaire pour que la golden master soit complete.
- ajouter une enum qui va contenir toutes les valeurs de commandes possibles, pour l'instant il y a "print", "report" et "unknowm". 
Pour ajouter une commande il faudrat ajouter une ligne dans l'enum, une strategy et une ligne dans le dictionnaire avec l'enum et la strategy.

La fin du refacto serait de faire le même travail que pour la PrintStrategy (extraire le code dans des fonctions et les tester) pour la ReportStrategy.
Ensuite il faudrait verifier que tous le code est tester pour ensuite supprimer les godlen master.
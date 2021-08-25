# REKURSION
Denne opgave knytter sig til følgende læringsmål:
* Jeg har viden om hvordan rekursion virker og adskiller sig fra iteration
* Jeg kan lave rekursive algoritmer


## Viden
Se [Colt Steele, Recursion Crash Course](https://www.youtube.com/watch?v=lMBVwYrmFZQ) om Martin og Dragen...

> *"Alt hvad du kan med rekursion, kan du med en løkke og en stak"*

Rekursion løser problemer hvor begge disse betingelser er til stede:
<ol>
    <li>Problemet har karakter af at være et træ.
    <li>Problemet kræver tilbagesporing.
</ol>

Et problem har karakter af være et træ, når der er en *rod*, og denne rod forgrener sig til grene, som igen forgrener sig hver især til flere grene, osv., dog ikke uendeligt: [Træ med mange grene, der har grene, der har grene...](https://commons.wikimedia.org/wiki/Category:Quality_images_of_Juglans#/media/File:Nonac_16_Noyer_novembre_2013.jpg)

Tilbagesporing betyder, blot at man går tilbage præcis den vej man kom. Man kunne forestille sig, at man er et egern i træet der leder efter en nød. Først går man op ad stammen og ud på en gren, men finder ikke nøden. I stedet for at gå ned på jorden igen, for at prøve en ny gren, går man tilbage ad den gren man er på, og ud på en ny gren - og så videre og så videre. Lad os antage at man finder nøden efter at have besøgt ni grene. I stedet for at gå ned af træet når nøden er fundet, går egernet tilbage til de besøgte grene, i den modsatte rækkefølge de blev besøgt i første gang. Og i stedet for at ud på hver gren, nøjes egernet bare med at kigge ud på grenen og ærgre sig over, at nøden ikke blev fundet her. Egernet går videre til næste gren, kigger ud ad den, ærgrer sig igen, og går videre. Da egernet kom ned ad træet, blev den glad igen, da den jo havde fundet en nød.


> Rekursion implementeres med en base case og en rekursiv case

En *base case* stopper rekursionen. En *rekursiv case* kalder funktionen (metoden) fra funktionen selv. Der skal altid være mindst én base case, og mindst én rekursiv case.

Se denne video:

<a href="http://www.youtube.com/watch?feature=player_embedded&v=AfBqVVKg4GE
" target="_blank"><img src="http://img.youtube.com/vi/AfBqVVKg4GE/0.jpg" 
alt="Recursion for Beginners: A Beginner's Guide to Recursion" width="240" height="180" border="10" /></a>


## Opgaver
### 1: Simpleste rekursion
Observer følgende kode:
```cs
int SimpleRecursion(int n)
{
    if(n == 0)  // Base case
        return -1;
    else        // Recursive case
        return SimpleRecursion(n - 1);
}
```
Resultatet når metoden kaldes med f.eks. `SimpleRecursion(3);` vil være -1. Lav ovenstående program og efterprøv F11 i Visual Studio. På denne måde får du indblik i hvordan rekursionen foregår. Hold øje med værdien af parameteren `n` i Locals vinduet i Visual Studio, og også metodestakken i Call Stack vinduet, særligt når `n` får værdien `0`.

### 2: Fibonacci
Du har allerede viden om Fionacci sekvensen fra videoen. her er pseudekode for algoritmen:
```
function Fibonacci(n)
    if n < 2
        return n
    else
        return Fibonacci(n-1) + Fibonacci(n-2)
```
Lav et program der udskriver sekvensen af Fibonacci tal for 2 til 20, f.eks. ved
```
procedure FibonacciSequence
    for n from 2 to 20
        print Fibonacci(n)
``` 
> Forskellen på en funktion og en procedure er at en funktion returnerer en værdi, hvorimod en procedure ikke returnerer en værdi.

Når programmet er lavet, så dobbelttjek at sekvensen er korrekt. 

Det viser sig, at når *n* bliver større så tager det længere og længere tid at køre programmet. Prøv f.eks. med *n = 40*. Lad os undersøge hvordan tiden udvikler sig med *n*:
```
procedure FibonacciSequence
    for n from 2 to 45
        start timer
        result = Fibonacci(n)
        stop timer
        reset timer
    print n, result and elapsed time
``` 
> *Hint: `System.Diagnostics.StopWatch`*

Indtast *n* med den tilhørende tid i Ticks et Excel ark og lav en graf. Hvordan udvikler grafen sig: lineært, med potens, eksponentielt? - og hvorfor?

### 3: Fakultet 
Lav et program der rekursivt beregner *n!* for *n* op til 14. Dit output skal se således ud:
```
1: 1
2: 2
3: 6
4: 24
5: 120
6: 720
7: 5040
8: 40320
9: 362880
10: 3628800
11: 39916800
12: 479001600
13: 1932053504
14: 1278945280
```
Her er anvendt en iteration, der for hver *n* kalder fakultetfunktionen og udskriver til konsollen. Signaturen på fakultetsfunktionen er 
```cs
int Faculty(int n)
```
Observér 14. iteration, hvad sker der mon her? Giv et bud og tilret koden, således output er korrekt for 21 iterationer.

### 4: Exceptions
Et objekt af `System.Exception` har en property `Inner`, også af typen `System.Exception`. Med andre ord *kan* en undtagelse have netop én indre undtagelse, og den undtagelse *kan* have en indre undtagelse, osv. Du skal konstruere et .NET 5 program i et klasse bibliotek, der rekursivt kan generere en `IEnumerable<Exception>` der indeholder alle undtagelserne, ordnet med roden først. Inden du programmerer, skriv da pseudokode hvori du identificerer base case og recursive case. Du skal teste din løsning med en unit test, inden du laver en NuGet pakke som uploades til nuget.org - den kunne f.eks. hedde `<ditProgrammørNavn>.ExceptionHandling`. På den måde kan du anvende denne pakke i alle dine fremtidige løsninger. Du finder information om hvordan man laver en NuGet pakke 
[her](https://www.youtube.com/watch?v=bCoVexnomuk).


## Ekstraopgaver
**A.** Tilret opgave 3 således at der kan foretages flere tusinde iterationer med korrekt output. *Hint: `System.Numerics`*.

**B.** Lav iterative løsninger for både Fibunacci og Fakultet. Sammenlign tiden det tager at køre programmerne med med grafer i Excel, med de respektive rekursive løsninger og konkluder på det.

**C.** Roslyn compileren kompilerer C# kode. Undersøg om Roslyn optimerer for tail-recursion. Tail-recursion er rekursion hvor den sidste instruktion i metoden er det rekursive kald.

**D.** For at perspektivere emnet, læs [dette](https://www.educative.io/blog/recursion) blogindlæg.

**E.** Lav en rekursion uden base case, og find ud af hvor mange kald der er på stakken når den frygtede StackOverflowException udløses.

**F.** Lav Towers of Hanoi med grafisk brugergrænseflade.
___
© 2021 Mads Mikkel Rasmussen. Alle rettigheder forbeholdes.
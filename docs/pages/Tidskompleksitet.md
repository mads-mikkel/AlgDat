# Tidskompleksitet
> ### **algorithm**
> Word uses by programmers when they do not want to explain what they did.

Denne opgave knytter sig til følgende læringsmål:
* Jeg kender til store O notation.
* Jeg kan foretage efterprøvning af en algoritmes tidskompleksitet.

## Viden
![Big-O Complexity Chart](https://github.com/mads-mikkel/DSA/blob/master/docs/img/tidskompleksitetsfunktioner.jpeg "Tidskompleksitetsfunktioner")

En algoritmes tidskompleksitet er afgørende for effektiviteten af algoritmen. Se disse to videoer:
* [Colt Steele, Complete Beginner's Guide to Big O Notation](https://www.youtube.com/watch?v=kS_gr2_-ws8)
* [Ned Batchelder, How Code Slows as Data Grows](https://www.youtube.com/watch?v=Ee0HzlnIYWQ)

## Opgaver
Følgende opgaver er givet som pseudokode. I hver opgave skal du:
1. beregne O ud fra pseudokoden 
2. efterprøve med konkret kode
3. lave en visuel graf over målingerne 
4. konkludere om din beregnede tidskompleksitet stemmer overens med dine målinger. 

Husk at læse på på dokumentationen for den/de anvendte operationer på den/de anvendte datastrukturer. Store O vil typisk fremgå af dokumentationen.
### Sum af elementer
```
function Sum(array)
    total = 0
    for each element in array
        add to total
    return total
```

### Find
```
function Find(array, index)
    value = array[index]
    return value
```

### Indeholder
```
function Contains(array, value)
    for each element in array
        if element equals value
            return true
    return false
```

### Fjern
Færdiggør selv pseudokoden inden trin 1-4:
```
function RemoveAt(array, index)
```
og igen for:
```
function RemoveByValue(array, value)
```

### Matchende elementer
Denne funktion skal returnere de elementer der er ens i `array1` og `array2`:
```
function Matching(array1, array2)
    // Færdiggør selv pseudokoden inden trin 1-4
    return matchingElements    
```

### Fakultet
```
function Factorial(n)
    if n equals 0
        return 1
    return n * Factorial(n - 1)
```

### Sortering
```
function Sort(array)
    for each element in array to n - 1
        for i in array to n - 1
            if array[i] > array[i + 1]
                Swap(array[i], array[i + 1]
```
Skriv selv en pseudokode til `Swap`. 

## Ekstra
**A.** Efterprøv `Sort` metoden på .NET Array klassen: Denne metode benytter en hybrid sorterings algoritme. Det vil sige, at forskellige sorteringsalgoritmer anvendes efter hvor stor *n* er. Det er ikke nødvendigt for dig at kende de forskellige sorteringsalgoritmer. Du skal efterprøve de forskellige algoritmer ved at variere *n* og måle resultaterne.

**B.** Efterprøv følgende metoder for .Net `List<T>`:
* Add, Contains, Remove, Reverse og Sort
om deres tidskompleksitet passer med dokumentationen. 

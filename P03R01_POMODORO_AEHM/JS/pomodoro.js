window.onload = () =>{
    let workTime;
    let breakTime;
    let restTime;
    let timesCompleted; // Cuantos tiempos completamos

    let cyclesGoal;         //Número de ciclos pomodoro que el usuario quiere completar
    let cyclesCompleted = 0; // Ciclos completados hasta el momento

    let currentTime; // minutos seteados
    let seconds = 0;

    let timerRunning = false; // bandera para controlar si está corriendo
    let paused = false;       // bandera para pausar
    let timerId;              // referencia al setTimeout para poder detenerlo
    
    /*Controla la lógica del ciclo Pomodoro:
    Cambia entre trabajo, descanso corto y descanso largo.
    Incrementa los contadores (timesCompleted, cyclesCompleted).
    Si se alcanzan los ciclos definidos (goalReached()), detiene el temporizador.*/
    function pomodoroController() {
        if (isRestTime()) {
            cyclesCompleted++;
            if (!goalReached()) {
                currentTime = restTime;
                timer();
                timesCompleted = 0;
            } else {
                console.log("Pomodoro finalizado");
                timerRunning = false; // liberar el botón al terminar
                startButton.textContent = "START"; // resetear texto del botón
                return; // detener ejecución
            }
            return;
        }
        if (timesCompleted % 2 == 0) {
            currentTime = workTime;
            timesCompleted++;
            timer();
            console.log("A trabajar " + timesCompleted);
        } else {
            currentTime = breakTime;
            timesCompleted++;
            timer();
            console.log("Break " + timesCompleted);
        }
    }
    /*Determina si inicia un descanso 
    largo (cuando se completan 7 intervalos de trabajo/descanso).*/
    function isRestTime() {
        return timesCompleted == 7;
    }
    //Verifica si ya se alcanzó el número de ciclos definidos por el usuario.
    function goalReached() {
        return cyclesGoal == cyclesCompleted;
    }
    
    /*Es el temporizador principal, resta segundos y minutos.
    Se ejecuta cada segundo con setTimeout.
    Si termina el tiempo, llama a pomodoroController() para decidir el siguiente intervalo.*/
    function timer() {
        if (paused) return; // si está pausado, no avanza

        if (currentTime > 0 || seconds > 0) {
            if (seconds == 0) {
                seconds = 59;
                currentTime--;
            } else {
                seconds--;
            }
            updateClock(); //Actualiza el reloj en pantalla.
            timerId = setTimeout(timer, 1000);
        } else {
            pomodoroController();
        }
    }

    /* Conexion con el fronten (reciben los elementos) */
    let clock = document.getElementById("clock");
    let cyclesInput = document.getElementById("cycles-input");
    let startButton = document.getElementById("start-button");
    let workTimeInput = document.getElementById("work-time");
    let breakTimeInput = document.getElementById("break-time");
    let restTimeInput = document.getElementById("rest-time");

    //Inicia el ciclo Pomodoro llamando al controlador.
    function startPomodoro() {
        console.log("Pomodoro iniciado");
        pomodoroController();
    }

    //Carga los valores desde los inputs y reinicia los contadores.
    function populateVariables() {
        console.log("variables populadas");
        workTime = parseInt(workTimeInput.value);
        breakTime = parseInt(breakTimeInput.value);
        restTime = parseInt(restTimeInput.value);
        cyclesGoal = parseInt(cyclesInput.value);
        timesCompleted = 0;
        seconds = 0;
    }

    //Controla el botón Start/Pause/Resume:
    startButton.onclick = () =>{
        if (!timerRunning) { //Si no está corriendo inicia el Pomodoro.
            // iniciar
            timerRunning = true;
            paused = false;
            populateVariables();
            startPomodoro();
            startButton.textContent = "PAUSE"; // cambiar texto del botón
        } else if (!paused) { //Si está corriendo y no pausado pausa el temporizador.
            // pausar
            paused = true;
            clearTimeout(timerId); // detener el setTimeout
            startButton.textContent = "RESUME";
            console.log("Temporizador en pausa");
        } else {
            // reanudar: Si está pausado reanuda el temporizador.
            paused = false;
            timer();
            startButton.textContent = "PAUSE";
            console.log("Temporizador reanudado");
        }
    };
    let resetButton = document.getElementById("reset-button");

    //Reinicia el contador del pomodoro
    function resetPomodoro() {
        clearTimeout(timerId); //Detiene el temporizador activo
        timerRunning = false;
        paused = false;
        timesCompleted = 0;
        cyclesCompleted = 0;
        seconds = 0;

        // Reinicia el reloj al valor inicial configurado en el input
        currentTime = parseInt(workTimeInput.value);
        clock.innerHTML = formatNumbers(currentTime) + ":00";

        // Resetea el texto del botón START
        startButton.textContent = "START";

        console.log("Pomodoro reiniciado");
    }
    // Asignar evento al botón reset
    resetButton.onclick = resetPomodoro;

    let clockMinutes;
    let clockSeconds;

    //Actualiza el reloj en pantalla mostrando minutos y segundos en formato MM:SS
    function updateClock() {
        clockMinutes = formatNumbers(currentTime);
        clockSeconds = formatNumbers(seconds);
        clock.innerHTML = clockMinutes + ":" + clockSeconds;
    }

    //Formatea los números para que siempre tengan dos dígitos ejemplo: 5 - "05".
function formatNumbers(time) {
  let formattedDigits;
  if (time < 10) {
    formattedDigits = "0" + time;
  } else {
    formattedDigits = time;
  }
  return formattedDigits;
}
};
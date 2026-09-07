const input = document.querySelector("#task-input"); //cosntante que recibe lo que se escribió en el input
const addBtn = document.querySelector(".btn-add"); //cosntante que recibe el botón para agregar el evento
const ul = document.querySelector("ul");  //cosntante que recibe el elemento donde se agregan las tareas
const empty = document.querySelector(".empty"); //cosntante que recibe el mensaje por defecto cuando no hay tareas

//Función de click para agregar una tarea
addBtn.addEventListener("click", (e) => {
  e.preventDefault(); //Evita que el formulario se recargue

  const text = input.value.trim(); //Obtiene el texto del input y elimina espacios

  if (text !== "") {
    const li = document.createElement("li"); //Crea un nuevo elemento li
    const p = document.createElement("p");  //Crea un nuevo elemento p
    p.textContent = text;

    li.appendChild(p); //Se asigna el parráfo dentro del li
    li.appendChild(addDeleteBtn()); //Se añade el botón borrar a cada li con la función addDeleteBtn()
    ul.appendChild(li); //Se agrega li dentro del elemento ul

    input.value = ""; //Limpia el campo de texto
    empty.style.display = "none"; //Oculta el mensaje por defecto cuando no hay tareas
  }
});
  //Función del botón eliminar para eliminar tareas.
function addDeleteBtn() {
  const deleteBtn = document.createElement("button"); //Se crea el botón para el html

  deleteBtn.textContent = "X";
  deleteBtn.className = "btn-delete";

  //Se agrega el evento click para el botón eliminar
  deleteBtn.addEventListener("click", (e) => {
    const item = e.target.parentElement; //Obtiene el li que contiene el botón
    ul.removeChild(item);       //Remueve el li de la lista

    const items = document.querySelectorAll("li");  //Revisa cuantas tareas quedan

    //Si no queda ningún li en la lista muestra de nuevo el mensaje por defecto cuando no hay tareas
    if (items.length === 0) {
      empty.style.display = "block";
    }
  });

  return deleteBtn; //Retorna el botón para agregarlo en cada tarea.
}

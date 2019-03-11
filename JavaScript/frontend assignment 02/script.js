function changeBGColor(){
    document.body.style.backgroundColor = "#134596";
}

function resetChangeBGColor(){
    document.body.style.backgroundColor = "#FFF";
}

function keyDown() {
    document.getElementById("key").style.color = "gray";
  }
  
  function keyUp() {
    document.getElementById("key").style.color = "orange";
  }

  function addToList(){
    let node = document.createElement("LI");
    let x = document.getElementById("list").value; 
    let textnode = document.createTextNode(x);
    node.appendChild(textnode);
    document.getElementById("myList").appendChild(node);
  }

  function openWindow(){
    window.open('http://nightflight.com/wp-content/uploads/TERRY-GILLIAM-1.jpg','targetWindow','toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=350,height=250')
  }

  function select(){
    document.getElementById("select").selectedIndex = "1";
  }

  function box(){
    document.getElementById("box").style.width = "300px";
    document.getElementById("box").style.height = "300px";
  }

  function a(){
      alert("Yes... nahhh");
  }

  function loadData(){
      let str = "Jeg er Shakal ";
      document.getElementById("area").innerHTML = str.repeat(2);
  }

  const komack = document.getElementById("komack");
  const p = document.getElementById("komackp");

  komack.addEventListener('click', updateButton);

  function updateButton() {
  if (komack.value === 'Start komack') {
    komack.value = 'Stop komack';
    p.textContent = 'The komack has started!';
  } else {
    komack.value = 'Start komack';
    p.textContent = 'The komack is stopped.';
  }
}

  function move() {
    let elem = document.getElementById("moveA");   
    let pos = 0;
    let id = setInterval(frame, 5);
    function frame() {
      if (pos == 350) {
        clearInterval(id);
      } else {
        pos++; 
        elem.style.top = pos + 'px'; 
        elem.style.left = pos + 'px'; 
      }
    }
  }

  function stopMoveA(){
    let elem = document.getElementById("moveA");
    elem.style.top = 0;
    elem.style.left = 0;
  }
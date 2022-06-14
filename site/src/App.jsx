import TextBox from "./Components/TextBox";
import textBoxData from "./data/textBoxData";
import Character from "./Components/Character";
import Person from "./Components/Person";
import characterData from "./data/characterData";
import personData from "./data/personData";
import "./style/style.css";

function App() {
  return (
    <>
      {/* the poster */}
      <div className="poster">
        <button className="poster__download__button">DOWNLOAD</button>
      </div>

      {/* The text box */}
      <div className="textbox--container">
        {textBoxData.map((item) => {
          return <TextBox title={item.title} content={item.content} />;
        })}
      </div>

      {/* The characters */}
      <div className="characters--container">
        <div className="character--title--number">
          <img
            src={require("./img/test/num.png")}
            className="character__number"
          />

          <h2 className="characters__title">Characters</h2>
        </div>

        <div className="characters__decoration"></div>
        {characterData.map((item) => {
          return <Character item={item} />;
        })}
      </div>

      <div className="gameplay">
        <TextBox
          title="Gameplay"
          content="Lorem ipsum dolor sit amet consectetur adipisicing elit. Provident cum dolor numquam consequuntur eos possimus atque dicta optio est enim?"
        />
        <video controls className="gameplay__video"></video>
      </div>
      <div className="card--container">
        {personData.map((item) => {
          return <Person item={item} />;
        })}
      </div>

      <div className="down--download--button">
        <button className="poster__download__button">DOWNLOAD</button>
      </div>
    </>
  );
}

export default App;

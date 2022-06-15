import AbilityTextBox from "./AbilityTextBox";
import abilityDataMC from "../data/abilityDataMC";
import abilityDataSC from "../data/abilityDataSC";

export default function Character(props) {
  return (
    <>
      <div className="character--container">
        <div className="character__drawing__description__name">
          <img
            src={require("../img/test/char.jpg")}
            alt=""
            className="characters__drawing"
          />
          <div className="character__name__discription">
            <h2 className="character__name">{props.item.name}</h2>
            <p className="characters__content">{props.item.description}</p>
          </div>
        </div>

        {/* ability */}
        <div className="characters__ability__container">
          {/* Cheking if charcter name is Taylor and rendering the abilities for the character*/}
          {props.item.name === "Taylor" &&
            abilityDataMC.map((item) => {
              return (
                <AbilityTextBox
                  type={item.type}
                  description={item.description}
                  picture={item.picture}
                />
              );
            })}

          {/* Cheking if charcter name is Penguin and rendering the abilities for the character*/}
          {props.item.name === "Penguin" &&
            abilityDataSC.map((item) => {
              return (
                <AbilityTextBox
                  type={item.type}
                  description={item.description}
                  picture={item.picture}
                />
              );
            })}
        </div>
      </div>
    </>
  );
}

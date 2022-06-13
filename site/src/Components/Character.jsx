import AbilityTextBox from "./AbilityTextBox";
import abilityDataMC from "../data/abilityDataMC";

export default function Character(props) {
  return (
    <>
      <img src={props.drawing} alt="" className="characters__drawing" />
      <h2 className="character__name">{props.name}</h2>
      <p className="characters__content">{props.description}</p>

      {/* ability */}
      <div className="characters__ability__container">
        {/* Cheking if charcter name is Taylor */}
        {props.name === "Taylor" &&
          abilityDataMC.map((item) => {
            return (
              <AbilityTextBox
                type={item.type}
                description={item.description}
                picture={item.picture}
              />
            );
          })}
      </div>
    </>
  );
}

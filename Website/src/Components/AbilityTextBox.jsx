export default function AbilityTextBox(props) {
  return (
    <>
      <div className="ability--box">
        <img src={props.picture} className="ability__picture" />
        <div className="ability__description__type">
          <h3 className="ability__type">Type: {props.type}</h3>
          <p className="ability__desctiption">{props.description}</p>
        </div>
      </div>
    </>
  );
}

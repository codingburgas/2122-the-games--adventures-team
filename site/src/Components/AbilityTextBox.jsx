export default function AbilityTextBox(props) {
  return (
    <>
      <div className="ability--box">
        <h3 className="ability__type">Type: {props.type}</h3>
        <img src={props.picture} className="ability__picture" />
        <p className="ability__desctiption">{props.description}</p>
      </div>
    </>
  );
}

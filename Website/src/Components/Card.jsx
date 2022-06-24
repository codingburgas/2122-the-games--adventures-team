export default function Person(props) {
  return (
    <>
      <div className="card">
        <div className="card--name--image">
          <div className="card__image"></div>
          <h2 className="card__name">{props.item.name}</h2>
        </div>
        <div className="card__info">
          <p className="card__info__github">Github: {props.item.github}</p>
          <p className="card__info__outlook">Email: {props.item.outlook}</p>
        </div>
      </div>
    </>
  );
}

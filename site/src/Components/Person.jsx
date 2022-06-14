export default function Person(props) {
  return (
    <>
      <div className="card">
        <img src={props.item.image} alt="" className="card__image" />
        <h2 className="card__name">{props.item.name}</h2>
        <div className="card__info">
          <p className="card__info__github">{props.item.github}</p>
          <p className="card__info__outlook">{props.item.outlook}</p>
        </div>
      </div>
    </>
  );
}

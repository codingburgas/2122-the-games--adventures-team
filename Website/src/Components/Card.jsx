export default function Card(props) {
  return (
    <>
      <div className="card--container">
        <img src="" alt="" className="card__icon" />

        <img src={props.item.img} alt="" className="card__image" />

        <h4 className="card__role">{props.item.role}</h4>
      </div>
    </>
  );
}

export default function TextBox(props) {
  return (
    <>
      <div className="textbox">
        <div className="textbox__title__image__container">
          <div className="textbox__number">{props.number}</div>
          <h2 className="textbox__title">{props.title}</h2>
        </div>
        <p className="textbox__content">{props.content}</p>
      </div>
    </>
  );
}

export default function TextBox(props) {
  return (
    <>
      <div className="textbox">
        <div className="textbox__number"></div>
        <h2 className="textbox__title">{props.title}</h2>
        <div className="textbox__decoration"></div>
        <p className="textbox__content">{props.content}</p>
      </div>
    </>
  );
}

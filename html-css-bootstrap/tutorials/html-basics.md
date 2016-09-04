# HTML Basics

## Contents
- [Todo](#todo)


### What is a Web Page?

The Internet is based on a text-based request/response protocol called **HTTP** (Hyper Text Transfer Protocol). HTTP allows us to send text across the internet; **HTML** (Hyper Text Markup Language) is just a special kind of text that a computer uses to format web pages in a special way. When a computer receives text in a `.html` or `.htm` file, it knows to display it in a certain way.

HTML files can be created in any text editor such as NotePad, NotePad++, Atom, SublimeText, Visual Studio, and many others.


### HTML Elements

HTML is comprised of **elements** or **tags**. Each tag must open and close, and other elements can be nested inside. For example, `<p>` is an opening paragraph tag, and `</p>` is a closing paragraph tag. This could be nested inside a `<div>` tag like so:

```html
<div>
  <p>I love IS!</p>
</div>
```

Some tags are **self-closing**, like the image (`img`) tag.

```html
<img src="logo.jpg" />
```

You may be wondering what `src="logo.jpg"` is doing. `src` is an **attribute** of the `img` tag; it contains a path to the image you would like to display. There are a variety of attributes that you can apply depending on the element you are using.


### Some basic HTML elements

This section will give a brief overview of some basic HTML elements. This list is by no means comprehensive.

**Hyperlink tags** create links between web pages. They use the `href` attribute to define where the link leads. You can also use the `target` attribute to define where the link should open (`target="_blank"` will open the link in a new tab).

```html
<!-- A link with an absolute path -->
<a href="https://google.com">Google Home Page</a>

<!-- A link with a relative path -->
<a href="resume.html">My resume</a>
```

**Image tags** allow you to embed images in your page. They use the `src` attribute to define the location of the image. The `alt` tag allows you to define text that will be displayed if the image fails to load or when the user overs over the image.

```html
<img src="http://placekitten.com/500/500" alt="A few kittens" />
```

**Lists** can be either ordered (`<ol>`) or unordered (`<ul>`) and contain many list items (`<li>`).

```html
<p>Top 3 continents by size</p>
<ol>
  <li>Asia</li>
  <li>Africa</li>
  <li>North American</li>
</ol>

<p>My skills (in no particular order)</p>
<ul>
  <li>HTML</li>
  <li>CSS</li>
  <li>Rocket science</li>
</ul>
```

HTML includes a variety of text formatting tags: `strong` for bold text, `em` for italic text, `h1` through `h6` for pre-formatted header text.

```html
<h1>My Title</h1>

<h3>A section heading</h3>
<p>Very <strong>important</strong> text that needs <em>emphasis</em>.</p>
```

There are also a variety of tags used to organize content into sections. These tags have little or no styling associated with them by default, but are a powerful tool for moving content around a page. Some examples of organizational tags are `<div>`, `<section>`, and `<article>`.


### More attributes

While many tags have attributes that perform special tasks, there are some attributes that are valid for almost any html element. The two most important of these attributes are `class` and `id`.

* `class`, which allows you to label elements to be selected by CSS or JavaScript
* `id`, which performs much like the `class` attribute except that ids must be unique on each page

These will be covered further in the CSS Basics tutorial.


### HTML structure

Each HTML document must follow some rules:

* Must have a `doctype`
* Must start and end with `<html>` and `</html>`
* Must contain a `head` and `body`

Here is what those rules look like in action:

```html
<!DOCTYPE html> <!-- Declaring the version of HTML. This format will suffice for modern applications. -->
<html>
  <head>
    <!-- Content for the head (information about the document) -->
  </head>
  <body>
    <!-- Content for the body (what will actually be displayed) -->
  </body>
</html>
```

It is best practice to format your HTML carefully to help with readability - you should always keep your indentation clean.


### `head` and `body`

The `<head>` section contains information about the page that is not shown directly to the user. Some examples of items you might put in the head are:

* `title` - the title shown in the tab or window in which the page is displayed
* `link` - a tag that defines the location of an associated css file
* `meta` - a tag which helps search engines and browsers know basic information about your website

The `<body>` section contains the content you wish to display directly to the user.

### Special characters

Some special characters are hard to type of may conflict with other reserved characters in HTML. For this, there are HTML escape sequences which will render the correct character. Here are some examples:

| Symbol name               | Escape sequence | Symbol  |
| ------------------------- | --------------- | ------- |
| Copyright sign            | `&copy;`        | &copy;  |
| Registered trademark sign | `&reg;`         | &reg;   |
| Trademark sign            | `&trade;`       | &trade; |
| Less than                 | `&lt;`          | &lt;    |
| Greater than              | `&gt;`          | &gt;    |
| Ampersand                 | `&amp;`         | &amp;   |

### More information

- [Mozilla HTML Element Reference](https://developer.mozilla.org/en-US/docs/Web/HTML/Element)
- [W3 Schools HTML Reference](http://www.w3schools.com/tags/)

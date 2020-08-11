package main

import (
	"errors"
	"fmt"
)

type song struct {
	title  string
	artist string
	year   int
}

type node struct {
	data song
	next *node
}

type linkedList struct {
	head *node
}

func (l *linkedList) add(data song) {
	if l.head == nil {
		l.head = &node{data: data}
		return
	}
	current := l.head
	for current.next != nil {
		current = current.next
	}
	current.next = &node{data: data}
}

func (l *linkedList) contains(title string) bool {
	if l.head == nil {
		return false
	}
	current := l.head
	for current.next != nil {
		if current.data.title == title {
			return true
		}
		current = current.next
	}
	if current.data.title == title {
		return true
	}
	return false
}

func (l *linkedList) remove(title string) (bool, error) {
	if l.head == nil {
		return false, errors.New("List is empty")
	}
	current := l.head
	if current.data.title == title {
		l.head = current.next
		return true, nil
	}
	for current.next != nil {
		if current.next.data.title == title {
			current.next = current.next.next
			return true, nil
		}
		current = current.next
	}
	return false, nil
}

func (l *linkedList) print() {
	if l.head == nil {
		fmt.Println("Playlist is empty")
		return
	}
	current := l.head
	fmt.Println(current.data.title)
	for current.next != nil {
		current = current.next
		fmt.Println(current.data.title)
	}
}

func main() {
	playlist := linkedList{}

	playlist.add(song{title: "Bat Out of Hell", artist: "Meatloaf", year: 1977})
	playlist.add(song{title: "Stairway to Heaven", artist: "Led Zeppelin", year: 1971})
	playlist.add(song{title: "Highway to Hell", artist: "AC/DC", year: 1979})

	playlist.print()

	fmt.Printf("Contains 'Tears in Heaven': %v\n", playlist.contains("Tears in Heaven"))

	playlist.add(song{title: "Tears in Heaven", artist: "Eric Clapton", year: 1992})

	fmt.Printf("Contains 'Tears in Heaven': %v\n", playlist.contains("Tears in Heaven"))

	removed, _ := playlist.remove("Bat Out of Hell")
	fmt.Printf("'Bat Out of Hell' removed: %v\n", removed)
	playlist.print()
}
